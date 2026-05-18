using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mob : Damagable
{
    protected Vector3 _direction;
    protected int _walkSpeed;
    protected override void Start()
    {
        base.Start();
        var mobData = _damagableData as MobData;
        _walkSpeed = mobData.WalkSpeed;
    }
    protected abstract void Walk();
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
}
