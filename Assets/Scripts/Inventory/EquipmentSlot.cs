using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EquipmentSlot : Slot
{
    [SerializeField] private ItemType TypeOfSlot;
    [SerializeField] private int _amount;

    public event UnityAction<string> InfoDispayed;
    public event UnityAction<ItemSO, EquipmentSlot> Selected;

    public ItemType SType => TypeOfSlot;

    public override void GetItem(ItemSO item, int amount)
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
            _item = null;
        }
    }

    public override void OnSelect()
    {
        Selected?.Invoke(_item, this);
    }
}
