using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    //Recipe Manager uses shaders to mix materials, idk how it works lol
    //Add Liquid objects onto manager and mix them.
    //public List<Liquid> availableLiquids; // List of all possible liquid
    private List<Liquid> currentLiquids = new List<Liquid>();
    public void AddLiquid(Liquid liquid)
    {
        currentLiquids.Add(liquid);
    }
    public Material MixLiquids(Liquid liquid)
    {
        if (currentLiquids.Count == 0)
            return null;

        // Create a new material to represent the mixed material
        Material mixedMaterial = new Material(Shader.Find("Standard"));

        // Blend textures of all currently mixed liquids
        foreach (var Liquid in currentLiquids)
        {
            // Blend main texture
            Texture2D mainTexture = (Texture2D)mixedMaterial.mainTexture;
            Texture2D liquidTexture = (Texture2D)liquid.teaMaterial.mainTexture;
            if (mainTexture == null)
                mixedMaterial.mainTexture = liquidTexture;
            else
                mixedMaterial.mainTexture = BlendTextures(mainTexture, liquidTexture);

            // Blend normal map (if available)
            if (mixedMaterial.HasProperty("_BumpMap") && liquid.teaMaterial.HasProperty("_BumpMap"))
            {
                Texture2D mainNormalMap = (Texture2D)mixedMaterial.GetTexture("_BumpMap");
                Texture2D liquidNormalMap = (Texture2D)liquid.teaMaterial.GetTexture("_BumpMap");
                if (mainNormalMap == null)
                    mixedMaterial.SetTexture("_BumpMap", liquidNormalMap);
                else
                    mixedMaterial.SetTexture("_BumpMap", BlendTextures(mainNormalMap, liquidNormalMap));
            }
        }

        return mixedMaterial;
    }
    // Utility method to blend two textures together
    private Texture2D BlendTextures(Texture2D texture1, Texture2D texture2)
    {
        // You can implement your own texture blending algorithm here
        // This example simply blends textures by averaging pixel colors
        int width = Mathf.Min(texture1.width, texture2.width);
        int height = Mathf.Min(texture1.height, texture2.height);
        Texture2D blendedTexture = new Texture2D(width, height);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Color color1 = texture1.GetPixel(x, y);
                Color color2 = texture2.GetPixel(x, y);
                Color blendedColor = Color.Lerp(color1, color2, 0.5f); // Blend colors by averaging
                blendedTexture.SetPixel(x, y, blendedColor);
            }
        }

        blendedTexture.Apply();
        return blendedTexture;
    }
}
