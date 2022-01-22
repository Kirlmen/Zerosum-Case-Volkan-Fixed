using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MultiplyTrigger : MonoBehaviour
{
    [SerializeField] int multiplyValue;
    bool oneTime = false;
    public UnityEvent onMultiplyEnter;

    //ontriggerenter causes bug. Currency multiplied each trigger enter. 10*2+10*3 etc.
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            onMultiplyEnter?.Invoke();
            if (other.GetComponent<Player>().isStop)
            {
                while (!oneTime)
                {
                    int currentCurrency = GameManager.Instance.GetCurrentCurrency();
                    currentCurrency *= multiplyValue;
                    int totalCurrency = PlayerPrefs.GetInt("Currency");
                    PlayerPrefs.SetInt("Currency", totalCurrency + currentCurrency);
                    GameManager.Instance.isWon = true;
                    oneTime = true;

                }

            }

        }
    }

}
