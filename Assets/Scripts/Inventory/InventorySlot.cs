using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventorySlot : Slot
{
    [SerializeField] private TMP_Text _amountText;
    [SerializeField] private int _amount;

    public event UnityAction<ItemSO, InventorySlot> Selected;
    public event UnityAction<string> InfoDispayed;

    public int Amount => _amount;

    public void AddToAmount(int value)
    {
        _amount += value;
        _amountText.text = _amount.ToString();
    }

    public override void GetItem(ItemSO item, int amount)
    {
        _item = item;
        _amount = amount;
        Show(item);
    }

    public override void NullifySlotData()
    {
        _isEmpty = true;
        _item = null;
        _amount = 0;
        _icon.color = new Color(1, 1, 1, 0);
        _icon.sprite = null;
        _amountText.text = "";
    }

    public override void RemoveItem(int value)
    {
        if(_item != null)
        {
            if(_amount <= 0)
            {
                NullifySlotData();
            }
            else
            {
                _amount -= value;
                _amountText.text = _amount.ToString();

                if (_amount <= 0)
                {
                    NullifySlotData();
                }
            }            
        }
    }

    public override void UseItem(Equipment equipment, Inventory inventory)
    {
        if (_item != null)
        {
            if (_item.Eatable == true)
            {
                if (HeroStats.Instance.Heal(1))
                {
                    SoundPlayer.Instance.PlayOtherSound(_item.UseSfx);
                    RemoveItem(1);

                }
                else
                {
                    string text = "Здоровье максимальное";
                    InfoDispayed?.Invoke(text);
                }
            }
        }

        if (_item != null)
        {
            if (_item.IsArmor == true)
            {
                foreach (EquipmentSlot slot in equipment.Slots)
                {
                    if (slot.SType == _item.IType)
                    {
                        ItemSO tempItem = _item;
                        
                        RemoveItem(1);                       

                        if (slot.IsEmpty == false) 
                        {
                            inventory.AddItem(slot.Item, 1);
                            equipment.RemoveStats();
                        }

                        slot.GetItem(tempItem);
                        equipment.AddStats();
                        
                        break;

                    }
                }
            }
        }
    }
   
    public override void Show(ItemSO item)
    {
        _icon.sprite = item.Icon;
        _icon.color = new Color(1,1,1,1);
        _amountText.text = _amount.ToString();
    }

    public override void OnSelect()
    {
        Selected?.Invoke(_item, this);
    }
}
