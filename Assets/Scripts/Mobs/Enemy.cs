using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Mob
{
    [SerializeField] private Weapon _weapon;
    private static Quaternion _buildableRotation;
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
        if (Vector3.Distance(transform.position, _agent.path.corners[^1]) < _agent.stoppingDistance)
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
        if(Vector3.Distance(transform.position, _agent.path.corners[^1]) < _agent.stoppingDistance)
        {
            _skeletonAnim.SetRunning(false);
        }
        else
        {
            _skeletonAnim.SetRunning(true);
        }
        Debug.Log(_agent.pathStatus);
        var path = new NavMeshPath();
        if(NavMesh.CalculatePath(transform.position, _target.position, NavMesh.AllAreas, path))
        {
            _agent.SetDestination(path.corners[^1]);
        }
    }
    protected override void Death()
    {
        enabled = false;
        _agent.enabled = false;
        _collider.enabled = false;
        _skeletonAnim.SetDead();
        Destroy(gameObject, 6);
    }
    public void UseWeapon()
    {
        _skeletonAnim.SetAttacking(true);
        _weapon.Use();
    }
}
