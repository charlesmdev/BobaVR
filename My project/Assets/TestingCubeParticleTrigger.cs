using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestingCubeParticleTrigger : MonoBehaviour
{
    private void OnParticleTrigger()
    {
        Debug.LogWarning("Detected particle, by trigger");
    }
    private void OnParticleCollision(GameObject other)
    {
        Debug.LogWarning("Detected particle, by collision: " + other.name);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.LogWarning("Detected particle, by trigger" + other.name);
    }
}
