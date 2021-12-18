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

    void Start()
    {
        playerTarget = FindObjectOfType<PlayerBase>().transform;
        rb = GetComponent<Rigidbody2D>();
        defaultState = enemyFSM;
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
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }
}
