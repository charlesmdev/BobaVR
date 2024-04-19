using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CupTriggerFill : MonoBehaviour
{
    private bool isFilling = false;
    public UnityEvent Fill, stopFill;
    public void OnTriggerEnter(Collider other)
    {
        ParticleSystem liquid = other.GetComponent<ParticleSystem>();
        if (liquid != null)
        {
            Debug.LogWarning("Cup is being triggered, not liquid");
            stopFill?.Invoke();
        }
        else
        {
            // Giving errors now??
            isFilling = true;
            Fill?.Invoke();
        }
    }
}
