using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject manu;
    Transform t;
    public bool cnt=false;

    public Transform player;
    private void Start()
    {

        t = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        //Debug.Log("manusript");
        //Debug.Log((player.position - t.position).magnitude);
        if (player == null || t == null)
        {
            Debug.Log("tag nhi mila");
        }
        if ((player.position - t.position).magnitude <= 10 && !cnt)
        {
            Debug.Log("UI");
            setactive();      
        }

    }
    public void close()
    {
        cnt = true;
        manu.SetActive(false);
    }
    void setactive()
    {
        //manu = GameObject.FindWithTag("UI");
        manu.SetActive(true);

        
    }
}
