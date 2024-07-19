using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour, IDamagable
{
    // Static variable to keep count across all instances
    private static float count;
    public float maxHealth;
    private SpawnEnemy e;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        // Find and assign the SpawnEnemy script
        e = FindObjectOfType<SpawnEnemy>();

        count = 0;
    }

    public void Damage(float dmgAmt)
    {
       

        currentHealth -= dmgAmt;
        if (currentHealth <= 0) // Use <= to ensure the condition is met properly
        {   
            Destroy(gameObject);
            e.Check();
        }
    }
}
