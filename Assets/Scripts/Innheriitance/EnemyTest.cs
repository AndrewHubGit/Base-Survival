using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MobTest
{
    public override void Die()
    {
        base.Die();
        Debug.Log("Coin Drop");
    }
}
