using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftSlots : MonoBehaviour
{
    [SerializeField] private CraftData[] _craftData;
    [SerializeField] private Inventory _inventory;
    public void Craft()
    {
        CraftData craftRecepie = null;
        for (int i = 0; i < _craftData.Length; i++)
        {
            craftRecepie = _craftData[i];
            for (int j = _inventory.InventoryMaxSize(); j < _inventory.CraftMaxSize(); j++)
            {
                if (_inventory.GetItem(j)?.GetData() != _craftData[i].CraftRecepie[j - _inventory.InventoryMaxSize()])
                {
                    craftRecepie = null;
                    break;
                }
            }
            if(craftRecepie != null)
            {
                break;
            }
        }
        if (craftRecepie == null)
        {
            Debug.Log("no recepie found");
            return;
        }
        for (int i = _inventory.InventoryMaxSize(); i < _inventory.CraftMaxSize(); i++)
        {
            _inventory.RemoveStack(i);
        }
        _inventory.AddItem(craftRecepie.ItemToCraft);
        Debug.Log("craft success");
    }
}
