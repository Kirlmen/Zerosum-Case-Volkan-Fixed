using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] ParticleSystem coinParticle;
    private int increase;
    private void OnEnable()
    {
        increase = Collectible.currencyValue;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collectible>())
        {
            other.GetComponent<Collectible>().Collect();
            Player.Instance.StageManager();
            if (other.CompareTag("Currency"))
            {
                GameManager.Instance.RuntimeIncrease(increase);
            }
        }
        if (other.CompareTag("Gold"))
        {
            coinParticle.Play();
        }
    }
}
