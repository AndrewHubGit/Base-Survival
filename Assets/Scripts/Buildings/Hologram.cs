using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Hologram : MonoBehaviour
{
    private BoxCollider _collider;
    public bool CanBuild(BoxCollider canBuildCollider)
    {
        _collider = canBuildCollider;
        var raycast = Physics.OverlapBox(transform.position, canBuildCollider.size * 80, Quaternion.identity, LayerMask.GetMask("Building"));
        return raycast.Length == 0;
    }
    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, _collider.size * 80);
    }
}
