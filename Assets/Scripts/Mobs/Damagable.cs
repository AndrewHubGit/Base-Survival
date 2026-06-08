using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    [SerializeField] protected DamagableData _damagableData;
    protected bool _isDead;
    protected MeshRenderer[] _renderer;
    protected Rigidbody _physics;
    protected int _maxHealth;
    protected int _health;
    protected BoxCollider _collider;
    protected virtual void Start()
    {
        _renderer = GetComponentsInChildren<MeshRenderer>();
        _collider = GetComponent<BoxCollider>();
        _physics = GetComponent<Rigidbody>();
        _maxHealth = _damagableData.Health;
        _health = _damagableData.Health;
    }
    public virtual void TakeDamage(int damage)
    {
        if (_isDead == true)
        {
            return;
        }
        _health = _health - damage;
        if (_health <= 0)
        {
            Death();
        }
    }
    protected virtual void Death()
    {
        _isDead = true;
        Destroy(gameObject);
    }
}
