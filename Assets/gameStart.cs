using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameStart : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();

        
    }

    public void start()
    {
        anim.SetBool("start",true);
        StartCoroutine(changescene());

    }
    IEnumerator changescene() {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadSceneAsync(1);
    }
}
