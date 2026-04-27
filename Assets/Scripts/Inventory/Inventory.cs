using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Inventory : MonoBehaviour
{
    private ItemSlotData[] _slotData;
    private int _inventoryMaximumSize = 23;
    [SerializeField] private TMP_Text[] _slotText;
    [SerializeField] private Image[] _slotImages;
    private void Awake()
    {
        _slotData = new ItemSlotData[_slotImages.Length];
    }
    public int CraftMaxSize()
    {
        return _slotData.Length;
    }
    public int InventoryMaxSize()
    {
        return _inventoryMaximumSize;
    }
    public void RemoveStack(int slotIndex)
    {
        if (_slotData[slotIndex] == null)
        {
            return;
        }
            _slotData[slotIndex].DecreaseAmount();
        _slotText[slotIndex].text = _slotData[slotIndex].ItemAmount().ToString();
        if (_slotData[slotIndex].ItemAmount() == 0)
        {
            ClearSlot(slotIndex);
        }
    }
    public void ClearSlot(int slotIndex)
    {
        _slotText[slotIndex].text = null;
        _slotImages[slotIndex].sprite = null;
        _slotData[slotIndex] = null;
    }
    public ItemSlotData GetItem(int slotIndex)
    {
        return _slotData[slotIndex];
    }
    public void SetItem(ItemSlotData itemData, int slotIndex)
    {
        _slotData[slotIndex] = itemData;
        _slotImages[slotIndex].sprite = itemData.GetData().Sprite;
        _slotText[slotIndex].text = itemData.ItemAmount().ToString();
    }
    public void AddItem(ItemData itemData)
    {
        for (int i = 0; i < _inventoryMaximumSize; i++)
        {
            if (_slotData[i]?.GetData() == itemData)
            {
                _slotData[i].IncreaseAmount();
                _slotText[i].text = _slotData[i].ItemAmount().ToString();
                return;
            }
        }
        for (int i = 0; i < _inventoryMaximumSize; i++)
        {
            if (_slotData[i] == null)
            {
                _slotData[i] = new ItemSlotData();
                _slotData[i].Data(itemData);
                _slotData[i].IncreaseAmount();
                _slotText[i].text = _slotData[i].ItemAmount().ToString();
                _slotImages[i].sprite = itemData.Sprite;
                break;
            }
        }
    }
}
public class ItemSlotData
{
    private int _itemAmount;
    private ItemData _itemData;
    public void Data(ItemData itemData)
    {
        _itemData = itemData;
    }
    public ItemData GetData()
    {
        return _itemData;
    }
    public void IncreaseAmount()
    {
        _itemAmount++;
    }
    public void DecreaseAmount()
    {
        _itemAmount--;
    }
    public int ItemAmount()
    {
        return _itemAmount;
    }
}
