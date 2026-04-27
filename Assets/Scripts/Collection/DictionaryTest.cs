using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryTest : MonoBehaviour
{
    [SerializedDictionary("Item", "Amount")]
    public SerializedDictionary<string, int> ItemSlot;
    private void Start()
    {
        ItemSlot["rock"] = 10;
    }
}
