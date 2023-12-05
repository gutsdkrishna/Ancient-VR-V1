using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class wolf: MonoBehaviour
{
    //public int chase = 0;

    //Pickup p;
    public NavMeshAgent ai;
    public List<Transform> destinations;
    public Animator aiAnim;
    public int walkSpeed, chaseSpeed, minIdleTime, maxIdleTime, destinationAmount;

    public float sightDistance, catchDistance, chaseTime, minChaseTime, maxChasetime, jumpscareTime;
    public bool walking, chasing;
    public Transform player;
    Transform curentDest;
    Vector3 dest;
    int randNum, randNum2, idleTime;
    public string deathScene;
    
    public Vector3 rayCastOffset;

    //public void BurnPaper()
    //{

    //    chaseSpeed += 10;
    //    return;
    //}

    private void Start()
    {
        //p = GameObject.FindGameObjectWithTag("Player").GetComponent<Pickup>();
        walking = true; chasing = false;
        randNum = Random.Range(1, destinationAmount);
        curentDest = destinations[randNum];



    }

    void ChasePlayer()
    {
        walking = false;
        StopCoroutine("stayIdle");
        StopCoroutine("chaseRoutine");
        StartCoroutine("chaseRoutine");


        aiAnim.ResetTrigger("walk");
        aiAnim.ResetTrigger("Buff");
        aiAnim.SetTrigger("chase");

        chasing = true;
    }

    private void Update()
    {
        //Debug.Log("chasing: " + chasing);
        //Debug.Log("walking: " + walking);


       // if (p.PGstate)

        {
            Vector3 direction = (player.position - transform.position).normalized;
            RaycastHit hit;
            //Debug.Log(direction);
            
            if(Physics.Raycast(transform.position,direction,out hit, sightDistance)) {

                if (hit.collider.gameObject.tag == "Player")
                {
                    walking = false;
                    StopCoroutine("stayIdle");
                    StopCoroutine("chaseRoutine");
                    StartCoroutine("chaseRoutine");


                    aiAnim.ResetTrigger("walk");
                    aiAnim.ResetTrigger("Buff");
                    aiAnim.SetTrigger("chase");

                    chasing = true;

                }


            }

            if (chasing == true)
            {

                dest = player.position;
                ai.destination = dest;
                ai.speed = chaseSpeed;
                if (ai.remainingDistance <= catchDistance)
                {

                    //player.gameObject.SetActive(false);
                    aiAnim.ResetTrigger("walk");
                    aiAnim.ResetTrigger("chase");
                    aiAnim.ResetTrigger("Buff");
                    aiAnim.SetTrigger("Attack1");
                    StartCoroutine(deathRoutine());
                    //chasing = false;

                }
            }


            else if (walking == true)
            {

                dest = curentDest.position;

                ai.destination = dest;
                ai.speed = walkSpeed;

                if (ai.remainingDistance <= ai.stoppingDistance)
                {
                    randNum2 = Random.Range(0, 2);
                    if (randNum2 == 0)
                    {
                        randNum = Random.Range(0, destinationAmount);
                        curentDest = destinations[randNum];
                    }

                    if (randNum2 == 1)
                    {
                        aiAnim.ResetTrigger("chase");
                        aiAnim.ResetTrigger("walk");
                        aiAnim.SetTrigger("Buff");
                        ai.speed = 0;
                        StopCoroutine("stayIdle");
                        StartCoroutine("stayIdle");
                        walking = false;
                    }
                }


            }
        }

    }

    IEnumerator stayIdle()
    {
        idleTime = Random.Range(minIdleTime, maxIdleTime);
        yield return new WaitForSeconds(idleTime);

        walking = true;
        randNum = Random.Range(0, destinationAmount);

        curentDest = destinations[randNum];
        aiAnim.ResetTrigger("Buff");
        aiAnim.ResetTrigger("chase");
        aiAnim.SetTrigger("walk");
    }

    IEnumerator chaseRoutine()
    {
        chaseTime = Random.Range(minChaseTime, maxChasetime);
        yield return new WaitForSeconds(chaseTime);
        walking = true;
        chasing = false;
        randNum = Random.Range(0, destinationAmount);
        curentDest = destinations[randNum];
        aiAnim.ResetTrigger("chase");
        aiAnim.ResetTrigger("Buff");
        aiAnim.SetTrigger("walk");

    }

    IEnumerator deathRoutine()
    {
        yield return new WaitForSeconds(jumpscareTime);
        //SceneManager.LoadSceneAsync(0);
        Debug.Log("attack");

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //       // if (p.PGstate)
    //        {
    //            StopAllCoroutines();
    //            ChasePlayer();
    //            Debug.Log("chase");
    //        }
    //    }
    //}


}
