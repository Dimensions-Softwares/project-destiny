using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Main Script of the player
public class Player : MonoBehaviour, IObserver<HealthBar>
{

    private HealthBar healthBar;

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
            GameManager.Instance.Subscribe(this);
        }
        CurrentHealth = maxHealth;
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

    public void OnCompleted()
    {
        RegisterHealthBar();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(HealthBar value)
    {
        throw new NotImplementedException();
    }

    private void RegisterHealthBar()
    {
        healthBar = GameManager.Instance.HealthBar;
    }


}
