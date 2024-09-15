using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public Transform player;               // Reference to the player
    public Transform pointA, pointB;        // Patrol points
    public float speed = 2f;               // Movement speed
    public float chaseRange = 5f;          // How close the player has to be for the monster to chase
    public float attackRange = 1f;         // How close the player has to be for the monster to attack

    private bool chasingPlayer = false;    // Is the monster currently chasing the player?
    private Vector3 targetPosition;        // Current target position for patrol

    private void Start()
    {
        targetPosition = pointA.position;  // Start by moving toward point A
    }

    private void Update()
    {
        // Calculate the distance to the player
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer <= attackRange)
        {
            // Attack the player when close enough
            AttackPlayer();
        }
        else if (distanceToPlayer <= chaseRange)
        {
            // Start chasing the player when they are within chaseRange
            chasingPlayer = true;
            ChasePlayer();
        }
        else
        {
            // If the player is out of range, patrol between the points
            chasingPlayer = false;
            Patrol();
        }
    }

    private void Patrol()
    {
        if (!chasingPlayer)
        {
            // Move towards the target patrol point (pointA or pointB)
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Check if the monster reached the target point, then switch to the other point
            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                targetPosition = targetPosition == pointA.position ? pointB.position : pointA.position;
            }
        }
    }

    private void ChasePlayer()
    {
        // Move towards the player's position
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    private void AttackPlayer()
    {
        // You can add an attack mechanic here (e.g., reduce player health)
        Debug.Log("Attacking player!");
    }
}
