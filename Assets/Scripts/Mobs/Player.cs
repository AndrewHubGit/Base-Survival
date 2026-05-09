using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mob
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private GameObject _loseScreen;
    [SerializeField] private GameObject _inventoryScreen;
    [SerializeField] private GameObject _hotBarScreen;
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        _healthBar.HPBar(_maxHealth, _health);
    }
    protected override void Walk()
    {
        Vector3 walkDirection = _direction * _walkSpeed;
        walkDirection.y = _physics.velocity.y;
        _physics.velocity = walkDirection;
    }
    protected override void Death()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        _inventoryScreen.SetActive(false);
        _hotBarScreen.SetActive(false);
        _loseScreen.SetActive(true);
    }
}
