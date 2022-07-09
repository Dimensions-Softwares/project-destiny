using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Main Script of the player
//Manages player's health and other general stats
public class Player : MonoBehaviour
{

    private HealthBar healthBar; //Health Bar UI Script

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
        if(GameManager.Instance.HealthBar != null)
        {
            RegisterHealthBar();
        }
        else
        {
            EventAgregator.HealthBarRegisteredEvent += OnHealthBarRegistered; //To be notified when the health
                                                                              //bar is available in the Game Manager
        }
        CurrentHealth = maxHealth;
    }

    private void TakeDamage(int damage)
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

    public void OnHealthBarRegistered(object sender, EventArgs args)
    {
        RegisterHealthBar();
    }

    private void RegisterHealthBar()
    {
        healthBar = GameManager.Instance.HealthBar;
    }

}
