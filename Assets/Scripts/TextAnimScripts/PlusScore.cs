using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlusScore : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    public void FloatScoreValue(int value)
    {
        if (value < 0)
        {
            scoreText.color = Color.red;
            scoreText.text = value.ToString();
        }
        else
        {
            scoreText.text = "+" + value;
        }
    }
}
