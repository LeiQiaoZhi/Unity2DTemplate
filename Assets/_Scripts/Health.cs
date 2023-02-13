using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public int maxHealth;
    
    protected int CurrentHealth;

    // Start is called before the first frame update
    public virtual void Awake()
    {
        CurrentHealth = maxHealth;
    }

    public virtual void ChangeHealth(int change, GameObject from)
    {
        CurrentHealth += change;
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    protected abstract void Die();
}
