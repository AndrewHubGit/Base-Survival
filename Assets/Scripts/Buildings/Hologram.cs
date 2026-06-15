using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Hologram : MonoBehaviour
{
    public bool CanBuild()
    {
        var raycast = Physics.OverlapBox(transform.position, Vector3.one * 6, Quaternion.identity, LayerMask.GetMask("Building"));
        return raycast.Length == 0;
    }
}
