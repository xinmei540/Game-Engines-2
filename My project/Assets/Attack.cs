using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform target;

    public LayerMask whatIsGround, whatIsTarget;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public float timeBetweenAttacks;

    bool alreadyAttacked;
    public GameObject projectile;

    public float sightRange, attackRange;
    public bool targetInSightRange, targetInAttackRange;

    private void Awake()
    {
        target = target.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        targetInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsTarget);
        targetInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsTarget);

        if(!targetInSightRange && !targetInAttackRange)
        {
            Patroling();
        } 

        else if(targetInSightRange && !targetInAttackRange)
        {
            ChaseTarget();
        }

        else if(targetInAttackRange && targetInSightRange)
        {
            AttackTarget();
        }
    }

    private void Patroling()
    {
        if(!walkPointSet)
        {
            SearchWalkPoint();
        }
        else
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if(distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void ChaseTarget()
    {
        agent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(target);

        if(!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

}
