using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListTest : MonoBehaviour
{
    public int[] n;
    public List<int> list;
    private void Start()
    {
        list.Remove(0);
    }
}
