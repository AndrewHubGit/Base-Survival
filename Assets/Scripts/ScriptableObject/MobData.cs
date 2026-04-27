using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "MobData", menuName = "Mobs")]

public class MobData : ScriptableObject
{
    [SerializeField] private int _health;
    [SerializeField] private int _walkSpeed;
    public int Health => _health;
    public int WalkSpeed => _walkSpeed;
}
