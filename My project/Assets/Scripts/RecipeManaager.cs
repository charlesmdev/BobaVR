using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Theme.Primitives;

public class RecipeManager : MonoBehaviour
{
    //Recipe Manager uses shaders to mix materials, idk how it works lol
    //Add Liquid objects onto manager and mix them.
    //public List<Liquid> availableLiquids; // List of all possible liquid
    public List<Liquid> currentLiquids = new List<Liquid>();
    private float targetPoint;
    public float time;
    public void AddLiquid(Liquid liquid)
    {
        currentLiquids.Add(liquid);
    }
    public Material MixLiquids()
    {
        if(currentLiquids.Count == 0)
        {
            return null;
        }
        Color mixedColor = currentLiquids[0].color;
        for (int i = 0; i < currentLiquids.Count; i++)
        {
            targetPoint += Time.deltaTime / time;
            mixedColor = Color.Lerp(mixedColor, currentLiquids[i].color, targetPoint);
        }
        
        Material mixedMaterial = new Material(Shader.Find("Standard"));
        mixedMaterial.color = mixedColor;
        Debug.LogWarning(mixedMaterial);

        return mixedMaterial;
    }
}
