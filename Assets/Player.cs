using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private HealthBar healthBar;

    private int currentHealth;
    [SerializeField] private int maxHealth = 100;

    public int CurrentHealth
    {
        get => currentHealth;

        private set
        {
            currentHealth = value;
            healthBar.SetHealth(currentHealth);
        }
    }

    private void Start()
    {
        CurrentHealth = maxHealth;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            takeDamage(20);
        }
    }

    private void takeDamage(int damage)
    {
        if (damage >= CurrentHealth)
        {
            CurrentHealth = 0;
        }
        else
        {
            CurrentHealth -= damage;
        }
    }


}
