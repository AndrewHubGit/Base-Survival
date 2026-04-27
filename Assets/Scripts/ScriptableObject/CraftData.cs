using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CraftData", menuName = "CraftableItems")]

public class CraftData : ScriptableObject
{
    [SerializeField] private ItemData _itemToCraft;
    [SerializeField] private ItemData[] _craftRecepie;
    public ItemData[] CraftRecepie => _craftRecepie;
    public ItemData ItemToCraft => _itemToCraft;
}
