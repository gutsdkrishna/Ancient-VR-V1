using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour
{
    // Start is called before the first frame update
    public Material mat;
    void Start()
    {
        //mat = GetComponent<Material>();
        mat.EnableKeyword("Emission");
    }

    // Update is called once per frame
    
}
