using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Conversion : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Animator anim;
    public GameObject manu;
    public GameObject UI;
    public Animator finishanim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("convert "+ (transform.position - player.transform.position).magnitude);
        if ((transform.position - player.transform.position).magnitude <= 33)
        {
            anim.SetBool("Convert",true);
            manu.gameObject.SetActive(true);
            
        }
       
        
        if ((manu.transform.position - player.transform.position).magnitude <= 3)
        {
            finishanim.SetBool("finish",true);
            UI.SetActive(true);
            //Wait(30f);
            StartCoroutine(Waitscene(30f));
            
        }
    }
    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        
    }
    IEnumerator Waitscene(float time)
    {
        Debug.Log("end scene");
        yield return new WaitForSeconds(time);
        Debug.Log("scene chaneg");
;        SceneManager.LoadSceneAsync(0);
    }
    
}
