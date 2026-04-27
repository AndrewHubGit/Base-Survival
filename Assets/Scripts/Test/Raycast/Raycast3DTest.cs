using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast3DTest : MonoBehaviour
{
    [SerializeField] private LayerMask _layer;
    private void Update()
    {
        var hit = Physics.OverlapSphere(transform.position, 2, _layer);
        for (int i = 0; i < hit.Length; i++)
        {
            Debug.Log(hit[i].GetComponent<Collider>());
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, 3);
    }
}
