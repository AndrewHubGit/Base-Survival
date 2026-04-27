using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast2DTest : MonoBehaviour
{
    [SerializeField] private LayerMask _layer;
    private void Update()
    {
        //var hit = Physics2D.Raycast(transform.position, Vector2.right * 5);
        var hit = Physics2D.CircleCastAll(transform.position, 2, Vector2.zero, 2, _layer);
        for (int i = 0; i < hit.Length; i++)
        {
            Debug.Log(hit[i].collider);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, 2);
        //Gizmos.DrawLine(transform.position, transform.position + Vector3.right * 5);
    }
}
