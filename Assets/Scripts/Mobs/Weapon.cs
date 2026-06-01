using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : UsableItem
{
    private int _damage;
    private float _attackDelay;
    private float _lastAttackTime;
    private AudioSource _audioSource;
    [SerializeField] private float _attackingDistance;
    [SerializeField] private LayerMask _layerDamage;
    [SerializeField] private WeaponData _weaponData;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _damage = _weaponData.Damage;
        _attackDelay = _weaponData.AttackSpeed;
    }
    public override bool Use()
    {
        if (Time.time > _attackDelay + _lastAttackTime)
        {
            //_audioSource.Play();
            var hit = Physics.OverlapBox(transform.position, Vector3.one * _attackingDistance, Quaternion.identity, _layerDamage);
            for (int i = 0; i < hit.Length; i++)
            {
                hit[i].GetComponent<Damagable>().TakeDamage(_damage);
            }
            _lastAttackTime = Time.time;
        }
        return false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, Vector3.one * _attackingDistance);
    }
}
