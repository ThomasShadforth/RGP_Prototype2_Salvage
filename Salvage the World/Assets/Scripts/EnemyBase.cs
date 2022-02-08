using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum enemyStates
{
    idle,
    walk,
    chase
}

public class EnemyBase : MonoBehaviour
{
    public Transform playerTarget;
    public float chaseRadius;
    public enemyStates enemyFSM;
    enemyStates defaultState;

    Rigidbody2D rb;

    public float moveSpeed;

    public Transform[] patrolArray;
    public Transform currentPatrolPoint;

    public float minimumDistance;
    public int patrolIndex;

    public int damageVal;
    void Start()
    {
        playerTarget = FindObjectOfType<PlayerBase>().transform;
        rb = GetComponent<Rigidbody2D>();
        defaultState = enemyFSM;
        if (patrolArray != null)
        {
            currentPatrolPoint = patrolArray[patrolIndex];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GamePause.GamePaused)
        {
            return;
        }

        

        if(Vector3.Distance(transform.position, playerTarget.position) < chaseRadius)
        {
            enemyFSM = enemyStates.chase;
        }
        else
        {
            enemyFSM = defaultState;
        }

        if(enemyFSM == enemyStates.walk)
        {
            checkPatrol();
        }

        if(enemyFSM == enemyStates.chase)
        {
            checkChase();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }

    public void checkChase()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, moveSpeed * GamePause.deltaTime);
    }

    public void checkPatrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentPatrolPoint.position, moveSpeed * GamePause.deltaTime);

        if(Vector3.Distance(transform.position, currentPatrolPoint.position) < minimumDistance)
        {
            Debug.Log("REACHED!");
            patrolIndex++;
            if(patrolIndex > patrolArray.Length - 1)
            {
                patrolIndex = 0;
            }

            currentPatrolPoint = patrolArray[patrolIndex];
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerBase>())
        {
            PlayerBase.instance.damagePlayer(damageVal);
        }
    }
}
