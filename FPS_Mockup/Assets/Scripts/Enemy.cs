using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;

    // when health reaches 0, continue to Die method
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    // destroys or kills GameObject/Enemy
    void Die()
    {
        Destroy(gameObject);
        
    }
}
