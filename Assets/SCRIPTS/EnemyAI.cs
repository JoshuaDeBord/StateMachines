using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent ai;
    public Transform patrolPoint;

    public enum EnemyState
    {
        Idle,
        Patrol,
        Chase,
        Attack
    }

    private EnemyState enemyState;
    private Animator anim;
    private Coroutine idleToPatrol;

    [Header("Floats")]
    public float distanceTotarget;

    private void Start()
    {
        ai = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        distanceTotarget = Mathf.Abs(Vector3.Distance(target.position, transform.position));

    }

    private void Update()
    {


        distanceTotarget = Mathf.Abs(Vector3.Distance(target.position, transform.position));

        switch (enemyState)
        {
            case EnemyState.Idle:
                SwitchState(0);
                ai.SetDestination(transform.position);
                if (idleToPatrol == null)
                {
                    StartCoroutine(SwitchToPatrol());
                }
                break;
            case EnemyState.Patrol:
                float distanceToPatrolPoint = Mathf.Abs(Vector3.Distance(patrolPoint.position, transform.position));
                if (distanceToPatrolPoint > 2)
                {
                    SwitchState(1);
                    ai.SetDestination(patrolPoint.transform.position);
                }
                else
                {
                    SwitchState(0);
                }
                if (distanceTotarget <= 15)
                {
                    enemyState = EnemyState.Chase;
                }
                break;

            case EnemyState.Chase:
                SwitchState(2);
                if (distanceTotarget <= 2)
                {
                    
                    enemyState = EnemyState.Attack;
                }
                else if (distanceTotarget > 15)
                {
                    enemyState = EnemyState.Idle;
                }
                ai.SetDestination(target.position);
                break;

            case EnemyState.Attack:
                SwitchState(3);
                if (distanceTotarget > 2 && distanceTotarget >= 15)
                {
                    enemyState = EnemyState.Chase;
                }
                else if (distanceTotarget > 15)
                {
                    enemyState = EnemyState.Idle;
                }
                break;

            default:

                break;
        }
    }

    private void SwitchState(int newState)
    {
        if (anim.GetInteger("State") != newState)
        {
            anim.SetInteger("State", newState);
        }
    }

    public IEnumerator SwitchToPatrol()
    {
        yield return new WaitForSeconds(5);
        enemyState = EnemyState.Patrol;
        idleToPatrol = null;
    }


}
