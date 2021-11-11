using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public event Action Death = delegate { };
    public event Action<int> LifeUpdated = delegate { };

    [SerializeField]
    private int maxHealth = 1;

    [SerializeField]
    private int currentHealth;

    private void Start()
    {
        ResetHealth();
        LifeUpdated(currentHealth);
    }

    public void ReduceHealth(int dmg)
    {
        currentHealth -= dmg;
        LifeUpdated(currentHealth);

        if (currentHealth <= 0)
            Death();
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
}
