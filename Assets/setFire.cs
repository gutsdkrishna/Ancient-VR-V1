using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setFire : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    Transform t;
    public Transform player;
    private void Start()
    {

        t = GetComponent<Transform>();
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        Debug.Log((player.position - t.position).magnitude);
        if(player==null || t == null)
        {
            Debug.Log("tag nhi mila");
        }
        if ((player.position - t.position).magnitude <= 10) {
            Debug.Log("setfire");
            anim.SetBool("SetFire",true);
        }

    }

}
