using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyAnimScript : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;


    public void ScoreHandle(int scoreValue)
    {
        scoreText.text = "+" + scoreValue;
    }
}
