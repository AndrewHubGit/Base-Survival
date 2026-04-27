using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DragItem : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private HotBar _hotBar;
    [SerializeField] private Image _selectedItemImage;
     private ItemSlotData _firstItem;
    private ItemSlotData _secondItem;
    private int _firstItemPosition;
    private void Update()
    {
        _selectedItemImage.transform.position = Mouse.current.position.ReadValue();
    }
    public void ItemSwap(int slotNumber)
    {
        _secondItem = _inventory.GetItem(slotNumber);
        _inventory.SetItem(_firstItem, slotNumber);
        if( _secondItem != null )
        {
            _inventory.SetItem(_secondItem, _firstItemPosition);
        }
        _selectedItemImage.gameObject.SetActive(false);
        _firstItem = null;
        _hotBar.OnItemSwapFinish(slotNumber);
    }
    public void ItemSelect(int slotNumber)
    {
        if (_firstItem != null)
        {
            ItemSwap(slotNumber);
            return;
        }
        _firstItemPosition = slotNumber;
        _firstItem = _inventory.GetItem(slotNumber);
        if (_firstItem == null)
        {
            return;
        }
        _selectedItemImage.gameObject.SetActive(true);
        _selectedItemImage.sprite = _firstItem.GetData().Sprite;
        _inventory.ClearSlot(slotNumber);
        _hotBar.OnItemSwapStart(_firstItemPosition);
    }
}
