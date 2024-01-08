using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EquipmentSlot : Slot
{
    [SerializeField] private ItemType TypeOfSlot;

    public event UnityAction<string> InfoDispayed;
    public event UnityAction<ItemSO, EquipmentSlot> Selected;

    public ItemType SType => TypeOfSlot;

    private new ItemSO _item;

    public new ItemSO Item => _item;

    public void GetItem(ItemSO item)
    {
        _item = item;
        _isEmpty = false;
        Show(_item);
    }

    public override void RemoveItem(int value)
    {
        if (_item != null)
        {            
            NullifySlotData();
        }
    }

    public override void OnSelect()
    {
        Selected?.Invoke(_item, this);
    }
}
