using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenButton : MonoBehaviour
{

    public Animator butonAnimator;

    private void Awake()
    {
        butonAnimator = GetComponent<Animator>();
        if (PlayerPrefs.GetInt("Currency") < PlayerPrefs.GetInt("Price"))
        {
            butonAnimator.SetFloat("SpeedParameter", 0);
        }
    }
    public void OpenAnim()
    {
        butonAnimator.SetBool("Open", true);
        GameManager.Instance.canBuy = true;
    }

    public void CloseAnim()
    {
        butonAnimator.SetBool("Open", false);
        GameManager.Instance.canBuy = false;
    }



}

