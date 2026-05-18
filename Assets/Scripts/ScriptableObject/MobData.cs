using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "MobData", menuName = "Mobs")]

public class MobData : DamagableData
{
    [SerializeField] private int _walkSpeed;
    public int WalkSpeed => _walkSpeed;
}
