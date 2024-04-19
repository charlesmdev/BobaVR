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
        Debug.LogWarning("Object: " + other.gameObject.name);
        ParticleSystem liquid = other.GetComponent<ParticleSystem>();
        Debug.LogWarning("Liquid: " + liquid);
        if (liquid == null)
        {
            Debug.LogWarning("Cup is being triggered, not liquid");
            stopFill?.Invoke();
        }
        else
        {
            Debug.LogWarning("Cup is being triggered, liquid");
            // Giving errors now??
            isFilling = true;
            Fill?.Invoke();
        }
    }
}
