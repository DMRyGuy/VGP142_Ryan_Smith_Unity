using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoblinController : MonoBehaviour
{
    public LayerMask whatIsGround, whatIsPlayer;
    public float lookRadius = 25f;
    // Shooting
    public float timeBetweenAttacks;
    public bool alreadyAttacked;
    public GameObject gobProjectile;
    public Animator anim;

    //States
    public bool playerInLookRadius, playerInAttackRange;

    // Patrolling
    public Vector3 patrolPoint;
    bool patrolPointSet;
    public float patrolPointRange;

    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        Debug.Log("Goblin has detected the player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        // chase
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            anim.SetBool("Walk", true);

            if (distance <= agent.stoppingDistance)
            {
                // Attack the target
                // Face the target
                FaceTarget();
            }

            //if (distance <= lookRadius - 5 && distance >= lookRadius - 10) ShootPlayer();
            if (distance <= lookRadius - 22) AttackPlayer();
            else anim.SetBool("Walk", true);
           // else Patrol();


        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void AttackPlayer()
    {
        anim.SetTrigger("Melee");
    }

    void ShootPlayer()
    {
        // stop enemy movement

        agent.SetDestination(transform.position);

        FaceTarget();

        if (!alreadyAttacked)
        {
            // shoot code here
            Rigidbody rb = Instantiate(gobProjectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 25f, ForceMode.Impulse);
            // Lob?
            rb.AddForce(transform.up * 7f, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    /*void Patrol()
    {
        if (!patrolPointSet) SearchPatrolPoint();

        if (patrolPointSet)
            agent.SetDestination(patrolPoint);

        Vector3 distanceToPatrolPoint = transform.position - patrolPoint;

        // patrolPoint reached
        if (distanceToPatrolPoint.magnitude < 1f)
            patrolPointSet = false;
    }

    private void SearchPatrolPoint()
    {
        // find a point withing range
        float randomZ = Random.Range(-patrolPointInRange, patrolPointInRange);
        float randomX = Random.Range(-patrolPointInRange, patrolPointInRange);

        patrolPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(SearchPatrolPoint, -transform.up, 2f, whatIsGround))
            patrolPoint = true;
    }*/
    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
