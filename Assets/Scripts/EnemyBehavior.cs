using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public float health = 100f;
    public float speed = 3.5f;
    public float damage = 100f;
    public float fieldOfViewAngle = 110f;
    public float viewDistance = 10f;
    public Transform[] patrolPoints;
    public Transform player;
    public float soundInvestigationTime = 5f; // Time to investigate a sound

    private int currentPatrolIndex;
    private NavMeshAgent navMeshAgent;
    private bool playerInSight;
    private Vector3 soundLocation;
    private bool investigatingSound;
    private float investigationTimer;


    // Initialize the NavMeshAgent and set the initial patrol point
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component missing from this game object");
            return;
        }

        navMeshAgent.speed = speed;
        currentPatrolIndex = 0;
        GoToNextPatrolPoint();
    }

    // Update the enemies behavior based on whether the player is in sight or a sound is being investigated, if neither returns to patrol
    void Update()
    {
        if (navMeshAgent == null)
            return;

        if (playerInSight)
        {
            ChasePlayer();
        }
        else if (investigatingSound)
        {
            InvestigateSound();
        }
        else
        {
            Patrol();
        }

        DetectPlayer();
    }

    // Set the next patrol point as the destination for the NavMeshAgent
    void GoToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0)
        {
            Debug.LogWarning("No patrol points set");
            return;
        }

        navMeshAgent.destination = patrolPoints[currentPatrolIndex].position;
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
    }

    // Continue patrolling if the agent is close to the current destination
    void Patrol()
    {
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
        {
            GoToNextPatrolPoint();
        }
    }

    // Set the player's position as the destination for the NavMeshAgent
    void ChasePlayer()
    {
        navMeshAgent.destination = player.position;
    }


    // Checks if the player is within the field of view and view distance, and sets playerInSight accordingly
    void DetectPlayer()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        float angle = Vector3.Angle(directionToPlayer, transform.forward);

        if (angle < fieldOfViewAngle * 0.5f && directionToPlayer.magnitude < viewDistance)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + transform.up, directionToPlayer.normalized, out hit, viewDistance))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    playerInSight = true;
                    return;
                }
            }
        }

        playerInSight = false;
    }

    // Set the sound location and start investigating the sound
    public void HearSound(Vector3 location)
    {
        soundLocation = location;
        Debug.Log("Heard a sound coming from " + location);
        investigatingSound = true;
        investigationTimer = soundInvestigationTime;
        navMeshAgent.destination = soundLocation;
    }


    // Investigate the sound location for a set duration, then returns to patrolling
    void InvestigateSound()
    {
        if (navMeshAgent.remainingDistance < 0.5f)
        {
            investigationTimer -= Time.deltaTime;
            if (investigationTimer <= 0)
            {
                investigatingSound = false;
                GoToNextPatrolPoint();
                Debug.Log("Finished investigating sound, returning to patrol");
            }
        }
    }


    // Draw gizmos to visualize the enemy's field of view and detection range
    void OnDrawGizmos()
    {
        if (playerInSight)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }

        Gizmos.DrawWireSphere(transform.position, viewDistance);

        Vector3 fovLine1 = Quaternion.AngleAxis(fieldOfViewAngle * 0.5f, transform.up) * transform.forward * viewDistance;
        Vector3 fovLine2 = Quaternion.AngleAxis(-fieldOfViewAngle * 0.5f, transform.up) * transform.forward * viewDistance;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, fovLine1);
        Gizmos.DrawRay(transform.position, fovLine2);
    }

    // Handles collision with the player and applies damage
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}