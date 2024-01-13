using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    [SerializeField] private Transform _panel;

    public List<EquipmentSlot> Slots = new List<EquipmentSlot>();

    public void GetSlots()
    {
        for (int i = 0; i < _panel.childCount; i++)
        {
            if (_panel.GetChild(i).GetComponent<EquipmentSlot>() != null)
            {
                Slots.Add(_panel.GetChild(i).GetComponent<EquipmentSlot>());
            }
        }
    }

    public bool AddItem(ItemSO item, int amount)
    {
        foreach (var slot in Slots)
        {
            if (slot.IsEmpty)
            {
                slot._isEmpty = false;
                slot.GetItem(item, amount);
                //SoundPlayer.Instance.PlayOtherSound(_addSfx);
                return true;
            }
        }

        return false;
    }

    public void AddStats()
    {
        foreach (var slot in Slots)
        {
            if(slot.Item != null)
            {
                HeroStats.Instance.SumStats(1,slot.Item.Armor, slot.Item.MinDamage, slot.Item.MaxDamage, slot.Item.Strength, slot.Item.Agility, slot.Item.Vitality, slot.Item.MaxHealth, slot.Item.AttackSpeed);
            }
        }
    }

    public void RemoveStats()
    {
        foreach (var slot in Slots)
        {
            if (slot.Item != null)
            {
                HeroStats.Instance.SumStats(-1, slot.Item.Armor, slot.Item.MinDamage, slot.Item.MaxDamage, slot.Item.Strength, slot.Item.Agility, slot.Item.Vitality, slot.Item.MaxHealth, slot.Item.AttackSpeed);
            }
        }
    }
}
