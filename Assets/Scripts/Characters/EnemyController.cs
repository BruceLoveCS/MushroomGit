using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyStates { GUARD,PATROL,CHASE,DEAD}

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    private EnemyStates enemyStates;

    private NavMeshAgent agent;

    [Header("Basic Settings")]

    public float sightRadius;

    public bool isGuard;

    private GameObject attackTarget;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        SwitchStates();
    }

    void SwitchStates()
    {
        if(FoundPlayer())
        {
            enemyStates = EnemyStates.CHASE;
            Debug.Log("’“µΩplayer");
        }

        switch (enemyStates)
        {
            case EnemyStates.GUARD:
                break;
            case EnemyStates.PATROL:
                break;
            case EnemyStates.CHASE:
                //TODO:chase player
                
                //TODO:attack if in the radius
                //TODO:with animation

                if(!FoundPlayer())
                {
                    //TODO:go back to former state
                }
                else
                {
                    agent.destination = attackTarget.transform.position;

                }


                break;
            case EnemyStates.DEAD:
                break;
        }
    }

    bool FoundPlayer()
    {
        var colliders = Physics.OverlapSphere(transform.position, sightRadius);

        foreach (var target in colliders)
        {
            if(target.CompareTag("Player"))
            {
                attackTarget = target.gameObject;
                return true;
            }
        }
        attackTarget = null;
        return false;
    }
}
