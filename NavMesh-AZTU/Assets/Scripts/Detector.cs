using System;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public event Action<Transform> OnCoinDetect;
    public event Action OnDetectGround;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            OnCoinDetect?.Invoke(other.transform);
        }

        if (other.CompareTag("Ground"))
        {
            OnDetectGround?.Invoke();
        }
    }

}