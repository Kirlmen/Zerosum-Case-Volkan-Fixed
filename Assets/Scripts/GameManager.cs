using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;



    public TMP_Text currencyText, buyPrice, startStackText, ingameCurrencyText, endlevelText, collectedCurText, totalCurrencyText, multiplyText, startLevelNum, gameLevelNum;
    [SerializeField] Button buyButton;
    [SerializeField] GameObject openButton;
    [SerializeField] GameObject startingMenu, gameScreen, endLevelScreen;


    public UnityEvent onLevelWon;
    public bool canBuy = false;



    [SerializeField] int startedCurrency;
    public bool isStarted = false;

    private void OnEnable()
    {
        if (!PlayerPrefs.HasKey("Currency"))
        {
            PlayerPrefs.SetInt("Currency", 0);
        }
        if (!PlayerPrefs.HasKey("Price"))
        {
            PlayerPrefs.SetInt("Price", 1);
        }
    }
    private void Awake()
    {
        Instance = this;

        currentScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Level", currentScene);

        startedCurrency = PlayerPrefs.GetInt("Currency");
        currencyText.text = startedCurrency.ToString();


        price = PlayerPrefs.GetInt("Price", 1);
        buyPrice.text = price.ToString();
        startStackText.text = PlayerPrefs.GetInt("LevelValue", 0).ToString();
        startLevelNum.text = PlayerPrefs.GetInt("Level").ToString();
        gameLevelNum.text = startLevelNum.text;

    }

    // Update is called once per frame
    void Update()
    {
        //openbutton deactivate
        if (!openButton.GetComponent<Button>().interactable) { openButton.SetActive(false); }
        else { openButton.SetActive(true); }

        if (canBuy && PlayerPrefs.GetInt("Currency") >= PlayerPrefs.GetInt("Price")) { buyButton.interactable = true; } //Buy button protection
        else { buyButton.interactable = false; }


        //price color
        if (PlayerPrefs.GetInt("Currency") < PlayerPrefs.GetInt("Price"))
        {
            buyPrice.color = Color.red;
        }

        if (isWon) //total currency text update
        {
            totalCurrencyText.text = PlayerPrefs.GetInt("Currency").ToString();
        }

    }

    public void TapToPlay()
    {
        isStarted = true;
        Player.Instance.AnimPlay(Player.PlayerStatus.Run);
        if (isStarted)
        {
            startingMenu.SetActive(false);
            gameScreen.SetActive(true);
        }
    }

    [SerializeField] int runtimeCurrency;
    public void RuntimeIncrease(int amount) //calculate the runtime currency
    {
        if (isStarted)
        {
            runtimeCurrency += amount;
            ingameCurrencyText.text = runtimeCurrency.ToString();
        }
    }


    public bool isWon = false;
    public void GameWon()
    {
        onLevelWon?.Invoke();
        endlevelText.text = PlayerPrefs.GetInt("Level").ToString();
        Player.Instance.AnimPlay(Player.PlayerStatus.Dance);
        Player.Instance.isStop = true;
        int collected;
        collected = int.Parse(ingameCurrencyText.text);
        collectedCurText.text = collected.ToString();

        //PlayerPrefs.SetInt("Currency", PlayerPrefs.GetInt("Currency") + runtimeCurrency);//saving the collected currency + saved currency
        //TODO: Next Scene button.

    }

    int currentScene;
    int nextScene;
    public void LoadNextLevel()
    {
        if (PlayerPrefs.GetInt("Level") < 5)
        {
            nextScene = PlayerPrefs.GetInt("Level") + 1;
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            SceneManager.LoadScene(1);
        }

    }


    [SerializeField] GameObject screenBuyButton;
    int price;
    [SerializeField] int priceIncreaseRate = 4;
    public void LevelUpButton() //TO MAXIMIZE LEVEL > NEED TO SPEND TOTAL 20.300 CURRENCY
    {
        // if (PlayerPrefs.GetInt("Currency") <= 0)
        // {
        //     return;
        // }
        //Price SetUP
        price = PlayerPrefs.GetInt("Price", 1);
        int curr = PlayerPrefs.GetInt("Currency");
        PlayerPrefs.SetInt("Currency", curr - price);
        currencyText.text = PlayerPrefs.GetInt("Currency").ToString();
        price += priceIncreaseRate;
        PlayerPrefs.SetInt("Price", price);

        //LevelCalculation
        int inc = PlayerPrefs.GetInt("LevelValue") + 1;
        PlayerPrefs.SetInt("LevelValue", inc);
        Player.Instance.levelSlider.value = PlayerPrefs.GetInt("LevelValue");
        Player.Instance.StageManager();

        //startstacktext update
        startStackText.text = PlayerPrefs.GetInt("LevelValue").ToString();

        buyPrice.text = PlayerPrefs.GetInt("Price").ToString();
        if (PlayerPrefs.GetInt("Price") > 400)  //if its reached full level
        {
            buyPrice.text = "Full!";
            screenBuyButton.SetActive(false); // buton açılır kapanırı yaptığında değiştir!!
        }


        if (PlayerPrefs.GetInt("LevelValue") > 100)
        {
            PlayerPrefs.SetInt("LevelValue", 100);
        }



    }

    public int GetCurrentCurrency()
    {
        return runtimeCurrency;
    }
}
