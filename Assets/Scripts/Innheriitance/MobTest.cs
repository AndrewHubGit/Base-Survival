using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MobTest : MonoBehaviour
{
    private int health = 5;
    private int damage = 5;
    private void Start()
    {
        TakeDamage();
    }
    public void TakeDamage()
    {
        health = health - damage;
        if(health == 0)
        {
            Die();
        }
        Debug.Log("damage");
    }
    public virtual void Die()
    {
        Debug.Log("Die");
    }
}
