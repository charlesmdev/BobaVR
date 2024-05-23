using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouringFromCup : MonoBehaviour
{
    public ParticleSystem myParticleSystem;
    private bool isPlaying = false;

    void Start()
    {
        myParticleSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        float angle = Vector3.Angle(Vector3.down, transform.forward);

        if (angle <= 90f)
        {
            if (!isPlaying)
            {
                myParticleSystem.Play();
                isPlaying = true;
                print("Start");
                print(isPlaying);
            }
        }
        else
        {
            if (isPlaying)
            {
                myParticleSystem.Stop();
                isPlaying = false;
                print("End");
                print(isPlaying);
            }
        }
    }
}
