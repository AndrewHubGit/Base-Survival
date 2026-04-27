using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Mob
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private float _attackDistance;
    private SkeletonAnimation _skeletonAnim;
    private NavMeshAgent _agent;
    private Transform _target;
    protected override void Start()
    {
        base.Start();
        _skeletonAnim = GetComponent<SkeletonAnimation>();
        _agent = GetComponent<NavMeshAgent>();
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if (Vector3.Distance(transform.position, _target.position) < _attackDistance)
        {
            UseWeapon();
        }
        else
        {
            _skeletonAnim.SetAttacking(false);
        }
    }
    public void TargetPosition(Transform target)
    {
        _target = target;
    }
    protected override void Walk()
    {
        if(Vector3.Distance(transform.position, _target.position) < _agent.stoppingDistance)
        {
            _skeletonAnim.SetRunning(false);
        }
        else
        {
            _skeletonAnim.SetRunning(true);
        }
        _agent.SetDestination(_target.position);
    }
    protected override void Death()
    {
        _skeletonAnim.SetDead();
    }
    public void UseWeapon()
    {
        _skeletonAnim.SetAttacking(true);
        _weapon.Use();
    }
}
