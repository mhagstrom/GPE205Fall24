using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int currentHealth = 100;
    [SerializeField] private int maxHealth = 100;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void OnDie()
    {
        Destroy (gameObject);
    }
    
    public void OnDamageTaken(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            OnDie();
        }
    }
}
