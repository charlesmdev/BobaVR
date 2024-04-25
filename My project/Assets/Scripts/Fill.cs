using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fill : MonoBehaviour
{
    // Perhaps get the Fill Object Material here?
    // Start is called before the first frame update
    public CupTriggerFill triggerFill;
    public Material teaType;
    public GameObject LiquidPivot;
    public Vector3 temp;

    public float maxFillHeight = 0.9f;
    public float fillRate = 0.1f;
    void Start()
    {
       triggerFill.Fill.AddListener(FillCup);
    }

    public void FillCup(GameObject liquid)
    {
        Debug.LogWarning("Filling cup." + liquid.name);
        teaType = liquid.GetComponent<Renderer>().material;
        Debug.LogWarning("Particle System: " + liquid.name + " " + teaType.name);
        // Get the y.scale of the Fill object
        // If y.scale is greater than 0.9 or whatever the maxheight is stop filling, play overfill; Else fill the cup starting from 0 to 0.9.
        // Check what type of tea it is, maybe by getting the material of the ParticleSystem.
        Renderer renderer = GetComponentInChildren<MeshRenderer>();
        if(renderer != null)
        {
            renderer.enabled = true;
            renderer.material = teaType;

            float fillAmount = Time.deltaTime * fillRate;
            temp = transform.localScale;
            temp.y += fillAmount;

            temp.y = Mathf.Clamp(temp.y, 0f, maxFillHeight);

            transform.localScale = temp;
        }
        else
        {
            Debug.LogWarning("Renderer not found");
        }
    }
    public void Spill()
    {

    }
    public void OverSpill()
    {

    }
}
