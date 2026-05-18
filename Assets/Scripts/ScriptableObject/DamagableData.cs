using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DamagableData", menuName = "Damagables")]

public class DamagableData : ScriptableObject
{
    [SerializeField] private int _health;
    public int Health => _health;
}
