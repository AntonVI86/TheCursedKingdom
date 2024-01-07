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
}
