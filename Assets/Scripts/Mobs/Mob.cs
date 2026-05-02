using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mob : MonoBehaviour
{
    [SerializeField] private MobData _mobData;
    protected BoxCollider _collider;
    protected Vector3 _direction;
    protected int _maxHealth;
    protected int _health;
    protected int _walkSpeed;
    protected Rigidbody _physics;

    protected virtual void Start()
    {
        _collider = GetComponent<BoxCollider>();
        _maxHealth = _mobData.Health;
        _physics = GetComponent<Rigidbody>();
        _health = _mobData.Health;
        _walkSpeed = _mobData.WalkSpeed;
    }
    protected abstract void Walk();
    protected abstract void Death();
    protected virtual void FixedUpdate()
    {
        Walk();
    }
    public void ChangeDirection(Vector3 direction)
    {
        _direction = direction;
    }
    public void SetRotation(Quaternion quaternion)
    {
        transform.rotation = quaternion;
    }
    public virtual void TakeDamage(int damage)
    {
        _health = _health - damage;
        if (_health <= 0)
        {
            Death();
        }
    }
}
