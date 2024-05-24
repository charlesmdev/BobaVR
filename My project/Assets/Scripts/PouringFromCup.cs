using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PouringFromCup : MonoBehaviour
{
    public ParticleSystem myParticleSystem;
    private bool isPlaying = false;
    Material teaMaterial;
    public Fill fillComponent; 

    void Start()
    {
        myParticleSystem = GetComponent<ParticleSystem>();
        if (fillComponent == null)
        {
            Debug.LogError("Fill component not assigned.");
        }
    }

    void Update()
    {
        float angle = Vector3.Angle(Vector3.down, transform.forward);

        // Combine these if statements
        if (angle <= 90f)
        {
            if (!isPlaying)
            {
                if (fillComponent != null) 
                {
                    Renderer renderer = myParticleSystem.GetComponent<ParticleSystemRenderer>();

                    teaMaterial = fillComponent.teaType;
                    renderer.material = teaMaterial;
                    print(teaMaterial);

                    myParticleSystem.Play();
                    isPlaying = true;
                    print("Start");

                    fillComponent.Pour(); // Not Working
                    print("Removing Liquid");
                }
            }
        }
        else
        {
            if (isPlaying)
            {
                myParticleSystem.Stop();
                isPlaying = false;
                print("End");
            }
        }
    }
}
