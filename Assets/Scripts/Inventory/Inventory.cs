using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Transform _panel;
    [SerializeField] public List<InventorySlot> Slots = new List<InventorySlot>();
    [SerializeField] private AudioClip _addSfx;

    public void GetSlots()
    {
        for (int i = 0; i < _panel.childCount; i++)
        {
            if (_panel.GetChild(i).GetComponent<InventorySlot>() != null)
            {
                Slots.Add(_panel.GetChild(i).GetComponent<InventorySlot>());
            }
            
        }
    }

    public bool AddItem(ItemSO item, int amount)
    {
        foreach (var slot in Slots)
        {
            if(slot.Item == item)
            {
                if(slot.Amount + amount <= item.MaxAmount)
                {
                    slot.AddToAmount(amount);
                    SoundPlayer.Instance.PlayOtherSound(_addSfx);
                    return true;
                }
            }
        }

        foreach (var slot in Slots)
        {
            if (slot.IsEmpty)
            {
                slot._isEmpty = false;
                slot.GetItem(item, amount);
                SoundPlayer.Instance.PlayOtherSound(_addSfx);
                return true;
            }
        }

        return false;

    }
}
