using UnityEngine;

public class Item : MonoBehaviour
{
    public int moneyValue = 10; // Default money value, can be set in the Inspector
    public float fallHeightThreshold = 2f; // Height from which the object must fall to make a sound
    public LayerMask enemyLayer; // Layer of the enemies
    public float soundRadius = 10f; // Radius within which enemies can hear the sound

    private Vector3 lastPosition;
    private bool hasFallen;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        if (!hasFallen && transform.position.y < lastPosition.y - fallHeightThreshold)
        {
            hasFallen = true;
            EmitSound();
        }

        lastPosition = transform.position;
    }

    public void EmitSound()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, soundRadius, enemyLayer);
        foreach (Collider enemy in enemies)
        {
            EnemyBehavior enemyBehavior = enemy.GetComponent<EnemyBehavior>();
            if (enemyBehavior != null)
            {
                enemyBehavior.HearSound(transform.position);
            }
        }
    }

    public void ResetFallDetection()
    {
        hasFallen = false;
        lastPosition = transform.position;
    }


}