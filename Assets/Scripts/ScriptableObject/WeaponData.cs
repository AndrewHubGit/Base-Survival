using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "WeaponData", menuName = "Weapons")]

public class WeaponData : ScriptableObject
{
    [SerializeField] private int _damage;
    [SerializeField] private float _attackSpeed;
    public int Damage => _damage;
    public float AttackSpeed => _attackSpeed;
}
