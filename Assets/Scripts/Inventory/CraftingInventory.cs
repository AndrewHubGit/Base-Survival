using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftingInventory : MonoBehaviour
{
    [SerializeField] private Transform _inventoryParent;
    [SerializeField] private Transform _craftingParent;
    [SerializeField] private Transform[] _itemSlots;
    private void SwitchSlotParent(Transform parent)
    {
        for (int i = 0; i < _itemSlots.Length; i++)
        {
            _itemSlots[i].SetParent(parent);
        }
    }
    public void OpenCrafting()
    {
        SwitchSlotParent(_craftingParent);
    }
    public void OpenInventory()
    {
        SwitchSlotParent(_inventoryParent);
    }
}