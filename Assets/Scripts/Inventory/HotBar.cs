using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HotBar : MonoBehaviour
{
    [SerializeField] private Image[] _hotbarImages;
    [SerializeField] private Color _deactivatedSlotColor;
    [SerializeField] private Transform _handPosition;
    [SerializeField] private Inventory _inventory;
    private GameObject _activeItem;
    private UsableItem _usableItem;
    private int _activeSlot;
    public void SelectSlot(int slotNumber)
    {
        _hotbarImages[_activeSlot].color = _deactivatedSlotColor;
        _hotbarImages[slotNumber].color = Color.yellow;
        _activeSlot = slotNumber;
        GameObject objectToSpawn = _inventory.GetItem(slotNumber)?.GetData().ActiveItem;
        if (_activeItem != null)
        {
            Destroy(_activeItem);
        }
        if(objectToSpawn == null)
        {
            return;
        }
        _activeItem = Instantiate(objectToSpawn, _handPosition.position, _handPosition.rotation, _handPosition);
        _usableItem = _activeItem.GetComponent<UsableItem>();
    }
    public void OnItemSwapStart(int itemPosition)
    {
        if(itemPosition == _activeSlot)
        {
            if (_activeItem != null)
            {
                Destroy(_activeItem);
            }
        }
    }
    public void OnItemSwapFinish(int itemPosition)
    {
        if (itemPosition == _activeSlot)
        { 
            SelectSlot(itemPosition);
        }
    }
    public void UseItem()
    {
        if( _usableItem != null)
        {
            if(_usableItem.Use() == true)
            {
                _inventory.RemoveStack(_activeSlot);
                SelectSlot(_activeSlot);
            }
        }
    }
    public void RotateItem(int rotation)
    {
        if (_usableItem is BuildableItems buildable)
        {
            buildable.RotateObject(rotation);
        }
    }
}
