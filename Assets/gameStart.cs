using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameStart : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    public Animator chidiya;
    public GameObject dest;
    public GameObject newPlayer;
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    public void star()
    {
        anim.SetBool("s",true);
        StartCoroutine(st());

    }
    IEnumerator st()
    {
        yield return new WaitForSeconds(5);
        chidiya.SetBool("start", true);
        Destroy(dest);
        yield return new WaitForSeconds(5);
        newPlayer.SetActive(true);  



    }
    
}
