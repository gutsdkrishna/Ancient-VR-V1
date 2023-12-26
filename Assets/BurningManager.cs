using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    public GameObject WholePlayer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       
        Debug.Log("burn " + (transform.position - player.transform.position).magnitude);
        if ((transform.position - player.transform.position).magnitude<=4)
        {
            player.transform.position = new Vector3(-146, 17, -177);
        }
    }
}
