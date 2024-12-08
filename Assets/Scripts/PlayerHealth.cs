using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;

    // Reduces the player's health by the specified amount
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    // Handles the player's death by quitting the application
    void Die()
    {
        Debug.Log("Player has died.");
        Application.Quit();   
        Destroy(GameObject.Find("Player")); //This is simply to mimick the player's death for the video
    }
}
