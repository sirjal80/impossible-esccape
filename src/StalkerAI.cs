using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement; // for restarting scene after player death

public class StalkerAI : MonoBehaviour
{
    public GameObject stalkerDest;        
    private NavMeshAgent stalkerAgent;
    public GameObject stalkerEnemy;       
    public static bool isStalking;
    public float killDistance = 2f;      
    public float moveSpeed = 3.5f;        

    void Start()
    {
        stalkerAgent = GetComponent<NavMeshAgent>();
        stalkerAgent.speed = moveSpeed;
    }

    void Update()
    {
        if (!isStalking)
        {
            stalkerEnemy.GetComponent<Animator>().Play("Idle");
            stalkerAgent.isStopped = true;
        }
        else
        {
            stalkerEnemy.GetComponent<Animator>().Play("Crouched Walking");
            stalkerAgent.isStopped = false;
            stalkerAgent.SetDestination(stalkerDest.transform.position);

            float distanceToPlayer = Vector3.Distance(transform.position, stalkerDest.transform.position);

            if (distanceToPlayer <= killDistance)
            {
                KillPlayer();
            }
        }
    }

    void KillPlayer()
    {
        // Play attack animation
        stalkerEnemy.GetComponent<Animator>().Play("Attack");

        // Optional small delay before killing
        StartCoroutine(DeathDelay());
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(1.2f); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
