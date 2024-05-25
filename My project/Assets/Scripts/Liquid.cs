using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Liquid : MonoBehaviour
{
    public Material teaMaterial;
    public Color color; 
    public string name;

    public Liquid(string name, Material teaType) // For Mixing materials without color
    {
        this.name = name;
        this.color = UnityEngine.Color.black;
        this.teaMaterial = teaType;
    }
    public Liquid(string name, Color color, Material teaType) // For Mixing materials with color
    {
        this.name = name;
        this.color = color;
        this.teaMaterial = teaType;
    }
}
