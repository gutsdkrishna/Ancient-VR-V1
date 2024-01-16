using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;

public class Height : MonoBehaviour
{
    // Start is called before the first frame update
    public XROrigin xr;
    public float value;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        xr.CameraYOffset = value;

    }
}
