using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int health;
    public event Action OnDie;

    public bool IsDie = false;

    void Start()
    {
        health = maxHealth;
        IsDie = false;
    }

    public void TakeDamage(int damage)
    {
        if (health == 0) return;
        
        health = Mathf.Max(health - damage, 0);

        if (health == 0)
        {
            IsDie = true;
            OnDie?.Invoke();
        }

        Debug.Log(health);
    }

}
