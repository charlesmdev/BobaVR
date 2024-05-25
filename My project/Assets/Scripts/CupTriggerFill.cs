using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CupTriggerFill : MonoBehaviour
{
    ParticleSystem liquid;
    //public UnityEvent Fill, stopFill;
    //Define a UnityEvent with a parameter of type Material
    [System.Serializable]
    public class FillEvent : UnityEvent<GameObject> { }
    public FillEvent Fill;

    void OnParticleCollision(GameObject other)
    {
        //Debug.LogWarning("Detected particle, by collision: " + other.name);
        liquid = other.GetComponent<ParticleSystem>();
        if(liquid != null)
        {
            //Debug.LogWarning("Filling");
            Fill.Invoke(other);
        }
        else
        {
            Debug.LogWarning("Stop Filling");
        }
    }
}
