using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distractable : Damagable
{
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        var color = Color.Lerp(Color.red, Color.white, (float)_health / _maxHealth);
        for (int i = 0; i < _renderer.Length; i++)
        {
            _renderer[i].material.color = color;
        }
    }
}
