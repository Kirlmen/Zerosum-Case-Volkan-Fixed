using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishLevel : MonoBehaviour
{
    public int requiredLevel;
    public UnityEvent triggerEnter;


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {

            if (Player.Instance.levelSlider.value >= requiredLevel)
            {
                triggerEnter?.Invoke();
            }
            else
            {
                GameManager.Instance.isWon = true;
                GameManager.Instance.GameWon();
            }
        }
    }
}
