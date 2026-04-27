using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mob
{
    [SerializeField] private HealthBar _healthBar;
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        _healthBar.HPBar(_maxHealth, _health);
    }
    protected override void Walk()
    {
        Vector3 walkDirectiion = _direction * _walkSpeed;
        walkDirectiion.y = _physics.velocity.y;
        _physics.velocity = walkDirectiion;
    }
    protected override void Death()
    {
        Debug.Log("Player Died");
    }
}
