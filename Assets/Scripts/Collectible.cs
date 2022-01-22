using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collectible : MonoBehaviour
{
    public UnityEvent onCollection;
    public bool shouldRotate;
    public static int currencyValue = 5;
    public int increaseValue;
    public int rotationSpeed;



    public void Collect()
    {
        onCollection?.Invoke();

        if (increaseValue <= -20)
        {
            Player.Instance.isStop = true;
        }
        else
        {
            Player.Instance.isStop = false;
        }
        Player.Instance.levelValue += increaseValue;
        Player.Instance.levelSlider.value = Player.Instance.levelValue;
        gameObject.GetComponent<BoxCollider>().enabled = false;
    }
    private void FixedUpdate()
    {
        if (shouldRotate)
        {
            transform.RotateAround(transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }

    }
}
