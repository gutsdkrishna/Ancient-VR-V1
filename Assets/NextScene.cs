using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.transform.position - transform.position).magnitude <= 3)
        {
            anim.SetBool("next",true);
            player.gameObject.SetActive(false);
            StartCoroutine(nextScene());

        }
    }
    IEnumerator nextScene()
    {
        yield return new WaitForSeconds(6f);
        SceneManager.LoadSceneAsync(2);
    }
}
