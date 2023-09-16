using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target ;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float turnSpeed = 5f;
    bool isProvoked = false;
    float distanceToTarget =Mathf.Infinity;
    
    NavMeshAgent navMeshAgent;
    Animator animator ;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        distanceToTarget = Vector3.Distance(target.position,transform.position);
        if(isProvoked)
        {
            animator.SetTrigger("move");    
            EngageTarget();
        }
        else
        {
            animator.SetTrigger("idle");
        }
        if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }
        
        
    }

    public void OnDamgeTaken()
    {
        this.isProvoked = true;
    }
    private void EngageTarget()
    {
        FaceTarget();
        if(distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
    
        if(distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void AttackTarget()
    {
        animator.SetBool("attack", true);
        
    }

    private void ChaseTarget()
    {
        animator.SetBool("attack", false);
        animator.SetTrigger("move");
        navMeshAgent.SetDestination(target.position);
    }
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation,Time.deltaTime*turnSpeed);
    }
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red ;
        Gizmos.DrawWireSphere(transform.position,chaseRange);
    }

}
