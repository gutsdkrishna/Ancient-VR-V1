using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour
{
    public Color emissionColor = Color.red; // Set your desired emission color in the inspector

    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();

        // Make sure the material supports emission
        rend.material.EnableKeyword("_EMISSION");
    }

    void Update()
    {
        // Modify the emission color based on your requirements
        rend.material.SetColor("_EmissionColor", emissionColor);
    }

}
