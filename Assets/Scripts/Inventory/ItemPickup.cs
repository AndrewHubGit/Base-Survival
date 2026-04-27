using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TagConstants.ITEM_TAG))
        {
            _inventory.AddItem(other.GetComponent<Item>().ItemData);
            Destroy(other.gameObject);
        }
    }
}
