using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Fill : MonoBehaviour
{
    // Perhaps get the Fill Object Material here?
    // Start is called before the first frame update
    public CupTriggerFill triggerFill;
    public Material teaType;
    public GameObject LiquidPivot;
    public Vector3 temp;

    public ParticleSystem myParticleSystem; // New
    private bool isPlaying = false;
    public float angle;

    public float maxFillHeight = 0.9f;
    public float fillRate = 0.1f;
    public float emptyRate = 0.1f; // Rate at which the cup is emptied

    public RecipeManager recipeManager;

    void Start()
    {
       triggerFill.Fill.AddListener(FillCup);
        //myParticleSystem = GetComponent<ParticleSystem>(); // New
    }

    void Update()
    {
        angle = Vector3.Angle(Vector3.down, myParticleSystem.transform.forward);
        // Combine these if statements
        if (angle <= 90f && transform.localScale.y > 0)
        {
            if (!isPlaying)
            {
                    Renderer renderer = myParticleSystem.GetComponent<ParticleSystemRenderer>();

                    renderer.material = teaType;
                //Debug.LogWarning("TeaType for Pour: " + teaType.name);

                    myParticleSystem.Play();
                    isPlaying = true;
                    print("Start");

            }
            Pour(); 
            Debug.LogWarning("Removing Liquid");
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
    public void FillCup(GameObject liquid)
    {
        //Debug.LogWarning("Filling cup." + liquid.name);
        teaType = liquid.GetComponent<Renderer>().material;
/*        for (int i = 0; i < recipeManager.currentLiquids.Count; i++)
        {
            if(recipeManager.currentLiquids[i].teaMaterial = teaType)
            {

            }
        }
        recipeManager.AddLiquid(new Liquid(teaType.name, teaType));
        Debug.LogWarning("Liquid Count: " + recipeManager.currentLiquids.Count);
        if (recipeManager.currentLiquids.Count > 1) // Checks if there is more than one liquid in the recipeManager
        {
           teaType = recipeManager.MixLiquids();
        }*/

        //Debug.LogWarning("Particle System: " + liquid.name + " " + teaType.name);
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

            //Debug.LogWarning("Filled temp.y: " + temp.y);

            transform.localScale = temp;         
        }
        else
        {
            Debug.LogWarning("Renderer not found");
        }
    }
    // Remove the Liquid
    public void Pour() // Was RemoveLiquid()
    {
        Renderer renderer = GetComponentInChildren<MeshRenderer>();
        if (renderer != null)
        {
            float emptyAmount = Time.deltaTime * emptyRate;
            temp = transform.localScale;

            Debug.LogWarning("Filled temp.y: " + temp.y);
                                           
            temp.y -= emptyAmount;

            temp.y = Mathf.Clamp(temp.y, 0f, maxFillHeight);

            Debug.LogWarning("Poured temp.y: " + temp.y);

            transform.localScale = temp;

            if (temp.y <= 0)
            {
                renderer.enabled = false;
            }
        }
        else
        {
            Debug.LogWarning("Renderer not found");
        }
    }
    public void OverSpill()
    {

    }
}
