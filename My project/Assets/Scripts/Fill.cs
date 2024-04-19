using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fill : MonoBehaviour
{
    // Perhaps get the Fill Object here?
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void FillCup()
    {
        // Get the y.scale of the Fill object
        // If y.scale is greater than 0.9 or whatever the maxheight is stop filling, play overfill; Else fill the cup starting from 0 to 0.9.
        // Check what type of tea it is, maybe by getting the material of the ParticleSystem.
    }
}
