using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoDisplayer : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _itemName;
    [SerializeField] private TMP_Text _itemType;
    [SerializeField] private TMP_Text _itemDiscription;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Equipment _equipment;

    [SerializeField] private Button _use;
    [SerializeField] private Button _remove;

    private ItemSO _item;
    private Slot _currentSlot;

    private void OnEnable()
    {
        foreach (InventorySlot slot in _inventory.Slots)
        {
            slot.Selected += Show;           
        }

        foreach (EquipmentSlot slot in _equipment.Slots)
        {
            slot.Selected += Show;
        }
    }

    private void OnDisable()
    {
        foreach (InventorySlot slot in _inventory.Slots)
        {
            slot.Selected -= Show;
        }

        HideInfo();
    }

    public void Show(ItemSO item, Slot slot)
    {
        if (slot.GetComponent<EquipmentSlot>())
        {
            _remove.interactable = true;
            _use.interactable = false;
        }

        if (slot.GetComponent<InventorySlot>())
        {
            _remove.interactable = false;
            _use.interactable = true;
        }

        HideInfo();
        _item = item;
        _currentSlot = slot;

        _use.onClick.AddListener(UseItem);
        _remove.onClick.AddListener(RemoveEquipItemToInventory);

        if(_item != null)
        {
            _icon.sprite = _item.Icon;
            _icon.color = new Color(1, 1, 1, 1);
            _itemName.text = _item.Label;
            _itemType.text = "“ип: " + _item.IType.ToString();
            _itemDiscription.text = _item.Description;
            _priceText.text = "÷ена " + _item.Price.ToString() + " зол.";
        }
    }

    public void HideInfo()
    {
        if (_item != null)
        {
            _item = null;

            _use.onClick.RemoveListener(UseItem);
            _remove.onClick.RemoveListener(RemoveEquipItemToInventory);

            _currentSlot = null;
            _icon.color = new Color(1, 1, 1, 0);
            _icon.sprite = null;
            _itemName.text = "";
            _itemType.text = "";
            _itemDiscription.text = "";
            _priceText.text = "";
        }
    }

    private void UseItem()
    {
        _currentSlot.UseItem(_equipment, _inventory);

        if(_currentSlot.IsEmpty == true)
        {
            HideInfo();
        }
    }

    private void RemoveEquipItemToInventory()
    {
        _currentSlot._isEmpty = true;
        _inventory.AddItem(_currentSlot.Item, 1);
        _currentSlot.Icon.color = new Color(1, 1, 1, 0);
        _currentSlot.Icon.sprite = null;
        _currentSlot = null;

        HideInfo();
    }
}
