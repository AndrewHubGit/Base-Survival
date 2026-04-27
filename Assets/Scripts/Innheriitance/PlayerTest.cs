using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MobTest
{
    public override void Die()
    {
        base.Die();
        Debug.Log("Game Over");
    }
}
