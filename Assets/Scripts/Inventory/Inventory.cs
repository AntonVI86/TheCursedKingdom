using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Transform _panel;
    [SerializeField] public List<Slot> Slots = new List<Slot>();
    [SerializeField] private AudioClip _addSfx;

    private void Start()
    {
        GetSlots();
    }

    private void GetSlots()
    {
        for (int i = 0; i < _panel.childCount; i++)
        {
            if (_panel.GetChild(i).GetComponent<Slot>() != null)
            {
                Slots.Add(_panel.GetChild(i).GetComponent<Slot>());
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
                slot.GetItem(item, amount);
                SoundPlayer.Instance.PlayOtherSound(_addSfx);
                slot._isEmpty = false;
                return true;
            }
        }

        return false;

    }
}
