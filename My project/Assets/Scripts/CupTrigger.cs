using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CupTrigger : MonoBehaviour
{
    private bool isFilling = false;
    public UnityEvent Fill, stopFill;
    void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning("Object: " + other.gameObject.name);
        ParticleSystem liquid = other.GetComponent<ParticleSystem>();
        if (liquid != null)
        {
            Debug.LogWarning("Cup is being triggered, not liquid");
            stopFill?.Invoke();
        }
        else
        {
            //isFilling = true;
            Fill?.Invoke();
        }
    }
}
