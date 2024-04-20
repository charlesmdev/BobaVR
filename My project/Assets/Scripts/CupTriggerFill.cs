using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CupTriggerFill : MonoBehaviour
{
    public UnityEvent Fill, stopFill;

    private void OnParticleCollision(GameObject other)
    {
        Debug.LogWarning("Hi, detects liquid");
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.LogWarning("Hi, detects object");
    }
}
