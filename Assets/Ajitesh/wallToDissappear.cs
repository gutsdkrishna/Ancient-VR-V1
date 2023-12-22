using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallToDissappear : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Wall;
    public GameObject wallToDisappear;
    public GameObject axe;
    public bool hit = false;
    public void SetHit()
    {
        hit = true;
    }
    private void Update()
    {
        Debug.Log((Wall.transform.position - axe.transform.position).magnitude);
        if ((Wall.transform.position - axe.transform.position).magnitude <= 5 && hit)
        {
            Debug.Log("hitted");
            wallToDisappear.SetActive(false);
        }
    }

}
