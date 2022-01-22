using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public static Player Instance;



    private Touch touch;

    [SerializeField] ParticleSystem swirlParticle;
    [SerializeField] GameObject playerCanvas, wonEffects;





    [Space]
    [Header("Stages")]
    public int levelValue;
    public Slider levelSlider;
    public GameObject[] level0;
    public GameObject[] level1;
    public GameObject[] level2;
    public GameObject[] level3;
    public GameObject[] level4;
    public Image levelFillImage;
    public Sprite levelFill0;
    public Sprite levelFill1;
    public Sprite levelFill2;
    public Sprite levelFill3;
    public Sprite levelFill4;
    public Animator[] playerAnimators;
    public UnityEvent onLevelUp;
    public UnityEvent onLevelDown;
    [Space]

    private Rigidbody rb;
    public bool isStop = false;

    private void Awake()
    {
        currentRunSpeed = maxRunSpeed;
        Instance = this;
        rb = this.gameObject.GetComponent<Rigidbody>();



        levelValue = PlayerPrefs.GetInt("LevelValue", 0);
        StageManager();
        levelSlider.value = levelValue;
    }
    void Start()
    {

    }

    void Update()
    {
        if (!GameManager.Instance.isStarted) { AnimPlay(PlayerStatus.Idle); isLevelUp = false; return; }
        if (isLevelUp)
        {
            AnimPlay(PlayerStatus.Cheer);
            isLevelUp = false;
        }


    }

    private void FixedUpdate()
    {

        if (PlayerPrefs.GetInt("LevelValue") > levelValue) //update levelvalue runtime
        {
            levelValue = PlayerPrefs.GetInt("LevelValue");
        }

        if (GameManager.Instance.isWon)
        {
            playerCanvas.SetActive(false);
            wonEffects.SetActive(true);
        }

        if (!GameManager.Instance.isStarted) { return; }
        playerCanvas.SetActive(true);
        Movement();
        GroundCheck();

    }


    [Space]
    [Header("Player Controls")] public float xAxisSpeed;
    public float limitX;
    public float maxRunSpeed;
    private float currentRunSpeed;
    float lastTouchedX;
    float yRotation;


    //if x speed < 110 camera starts to jitter
    private void Movement()
    {


        if (!GameManager.Instance.isStarted) { return; }
        if (isStop) { return; }

        float newX = 0;
        float touchXDelta = 0;

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                lastTouchedX = Input.GetTouch(0).position.x;
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {

                touchXDelta = 5 * (Input.GetTouch(0).position.x - lastTouchedX) / Screen.width;
                lastTouchedX = Input.GetTouch(0).position.x;
            }
        }
        //PC input controls
        else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X");
        }


        AnimPlay(PlayerStatus.Run);

        newX = transform.position.x + xAxisSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitX, limitX);

        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + currentRunSpeed * Time.deltaTime);
        transform.position = newPosition;
    }


    private int level;
    private int prevLevel;
    private bool isLevelUp = false;
    public void StageManager() //stages
    {
        if (levelValue < 0) { levelValue = 0; }
        if (levelValue > 100) { levelValue = 100; }

        //Stages
        if (levelValue < 25)
        {
            level = 0;
        }
        else if (levelValue >= 25 && levelValue < 50)
        {
            level = 1;
        }
        else if (levelValue >= 50 && levelValue < 70)
        {
            level = 2;
        }
        else if (levelValue >= 70 && levelValue < 90)
        {
            level = 3;
        }
        else if (levelValue >= 90 && levelValue <= 100)
        {
            level = 4;
        }

        if (prevLevel != level)
        {
            if (prevLevel < level) //levelup
            {
                onLevelUp?.Invoke();
                LevelUpAnim();
                prevLevel = level;
            }
            else if (prevLevel > level) //leveldown
            {
                onLevelDown?.Invoke();

                prevLevel = level;
            }
        }

        foreach (var item in level0)
        {
            item.SetActive(level == 0);
        }
        foreach (var item in level1)
        {
            item.SetActive(level == 1);
        }
        foreach (var item in level2)
        {
            item.SetActive(level == 2);
        }
        foreach (var item in level3)
        {
            item.SetActive(level == 3);
        }
        foreach (var item in level4)
        {
            item.SetActive(level == 4);
        }


        if (level == 0)
        {
            levelFillImage.sprite = levelFill0;
        }
        else if (level == 1)
        {
            levelFillImage.sprite = levelFill1;
        }
        else if (level == 2)
        {
            levelFillImage.sprite = levelFill2;
        }
        else if (level == 3)
        {
            levelFillImage.sprite = levelFill3;
        }
        else if (level == 4)
        {
            levelFillImage.sprite = levelFill4;
        }


    }


    public enum PlayerStatus //anim status
    {
        Idle,
        Run,
        Sad,
        Dance,
        Falling,
        Cheer,
        Spin
    }

    public static readonly int Status = Animator.StringToHash("Status");
    public void AnimPlay(PlayerStatus status)
    {
        switch (status)
        {
            case PlayerStatus.Idle:
                foreach (var item in playerAnimators)
                {
                    item.SetInteger(Status, 0);
                }
                break;
            case PlayerStatus.Run:
                foreach (var item in playerAnimators)
                {
                    item.SetInteger(Status, 1);
                    // item.Update(0); buggy
                }
                break;
            case PlayerStatus.Sad:
                foreach (var item in playerAnimators)
                {
                    item.SetInteger(Status, 2);
                }
                break;
            case PlayerStatus.Dance:
                foreach (var item in playerAnimators)
                {
                    item.SetInteger(Status, 3);
                }
                break;
            case PlayerStatus.Falling:
                foreach (var item in playerAnimators)
                {
                    item.SetInteger(Status, 4);
                }
                break;
            case PlayerStatus.Cheer:
                foreach (var item in playerAnimators)
                {
                    item.SetInteger(Status, 5);
                }
                break;
            case PlayerStatus.Spin:
                foreach (var item in playerAnimators)
                {
                    item.SetInteger(Status, 6);
                }
                break;
        }
    }


    [Space]
    [Header("GroundCheck")] public RaycastHit groundHit;
    public LayerMask groundLayerMask;
    public float groundCheckRange;
    public bool isGrounded;
    public void GroundCheck()
    {
        isGrounded = Physics.Raycast(transform.localPosition, -transform.up, out groundHit, groundCheckRange, groundLayerMask);

        if (!isGrounded)
        {
            swirlParticle.Play();
            //rb.drag = 2f;
            AnimPlay(PlayerStatus.Falling);
        }
        else if (isGrounded)
        {
            swirlParticle.Stop();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawRay(transform.localPosition, -transform.up * groundCheckRange);
    }


    public void LevelUpAnim()
    {
        isLevelUp = true;
    }
}
