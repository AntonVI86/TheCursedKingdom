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
                if(item.IsArmor == true)
                {
                    break;
                }

                if(slot.Amount + amount < item.MaxAmount)
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

    public void Save()
    {
        PlayerPrefs.DeleteAll();

        for (int i = 0; i < Slots.Count; i++)
        {
            if(Slots[i].IsEmpty == false)
            {
                PlayerPrefs.SetInt("Slot" + i, i);
                PlayerPrefs.SetInt("ItemInSlot" + Slots[i].Item.ItemID, Slots[i].Item.ItemID);
                PlayerPrefs.SetInt("ItemAmount" + Slots[i].Item.ItemID, Slots[i].Amount);
            }
        }
    }

    public void Load()
    {

        for (int i = 0; i < Slots.Count; i++)
        {
            if(PlayerPrefs.HasKey("Slot" + i))
            {
                Slots[i].GetItem(ItemData.Instance.Items[PlayerPrefs.GetInt("ItemInSlot" + Slots[i].Item.ItemID)], PlayerPrefs.GetInt("ItemAmount" + Slots[i].Item.ItemID));
            }
        }
    }
}
