using System.Collections;
using System.Collections.Generic;
using UnityEngine;
Using UnityEngine.AI;

public class EnemyAiTutorial : MonoBehaviour
{
    public NavMeshAgent agent ; 

    public Transform player;

    public Layer Mask whatIsGround, whatIsPlayer;

    //
    public Vector3 walkpoint; 
    bool walkpointSet;
    public float walkpointRange;

    //Attacking
    Public float timeBetweenAttacks;
    bool alreadyAttacked ;

    //  States 
    public float sightRange, attackRange;
    public bool playerInSightRange,player playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform ;
        agent = GetComponent<NavMeshAgent>();
    }
         private void private void Update() 
         {
           // Checkfor sight and attack range
           playerInSightRange = Physics.CheckSphere(transfrom.position, sightRange,whatIsPlayer);
           playerInAttackRange = Physics.CheckSphere(transfrom.position,attackRange,whatIsPlayer);

           if (!playerInSightRange) && ! playerInAttackRange)Patroling();
           if (!playerInSightRange) && ! playerInAttackRange)ChasePlayer();
           if (!playerInAttackRange) && ! playerInSightRange)AttackPlayer();
         }
        private void Patroling()
        {
          if (!walkpointSet) SearchWalkPoint();

           if (!walkpointSet)
               agent.SetDestination(walkPoint);
            Vector3 distanceToWalkPoint
        }

         private void ChasePlayer()
        {
            
        }

         private void AttackPlayer()
        {
            
        }
    

}
