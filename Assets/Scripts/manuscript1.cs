using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manuscript1 : MonoBehaviour
{
    public GameObject manu;
    public GameObject photo;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("on trigger");
        if (other.tag == "Player")
        {
            manu.SetActive(true);
            photo.SetActive(true);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        manu.SetActive(false);
    }
    

}
