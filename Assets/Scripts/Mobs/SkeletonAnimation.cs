using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimation : MonoBehaviour
{
    public const string IsRunning = "IsRunning";
    public const string IsAttacking = "IsAttacking";
    public const string IsDead = "IsDead";
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void SetRunning(bool isRunning)
    {
        _animator.SetBool(IsRunning, isRunning);
    }
    public void SetAttacking(bool isAttacking)
    {
        _animator.SetBool(IsAttacking, isAttacking);
    }
    public void SetDead()
    {
        _animator.SetTrigger(IsDead);
    }
}
