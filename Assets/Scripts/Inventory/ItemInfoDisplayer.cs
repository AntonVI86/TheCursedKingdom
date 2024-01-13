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

    [SerializeField] private TMP_Text _statTextPrefab;
    [SerializeField] private StatTextCreator _statTextPosition;

    [SerializeField] private Inventory _inventory;
    [SerializeField] private Equipment _equipment;

    [SerializeField] private Button _use;
    [SerializeField] private Button _removeInventoryItem;
    [SerializeField] private Button _removeEquipItem;

    [SerializeField] private ItemSO _item;
    [SerializeField] private Slot _currentSlot;

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

        foreach (EquipmentSlot slot in _equipment.Slots)
        {
            slot.Selected -= Show;
        }

        HideInfo();
    }

    public void Show(ItemSO item, Slot slot)
    {
        if (slot.GetComponent<EquipmentSlot>())
        {
            if (slot.IsEmpty)
            {
                _use.interactable = false;
                _removeEquipItem.gameObject.SetActive(false);
                _removeInventoryItem.gameObject.SetActive(false);
            }

            if (slot.IsEmpty == false)
            {
                _use.interactable = false;
                _removeEquipItem.gameObject.SetActive(true);
                _removeInventoryItem.gameObject.SetActive(false);
                _removeEquipItem.onClick.AddListener(RemoveEquipItemToInventory);
            }
        }

        if (slot.GetComponent<InventorySlot>())
        {
            _use.interactable = false;
            _removeEquipItem.gameObject.SetActive(false);
            _removeInventoryItem.gameObject.SetActive(true);

            if (slot.GetComponent<InventorySlot>().Item != null)
            {
                if (slot.Item.IsArmor || slot.Item.Eatable)
                {
                    _use.interactable = true;
                }
            }

            _removeInventoryItem.onClick.AddListener(() => RemoveItemFromInventory());
        }

        HideInfo();
        _item = item;
        _currentSlot = slot;

        _use.onClick.AddListener(UseItem);

        if (_item != null)
        {
            _icon.color = new Color(1, 1, 1, 1);
            _icon.sprite = _item.Icon;
            _itemName.text = _item.Label;
            _itemType.text = "“ип " + _item.IType.ToString();
            _item.ShowInfo(_statTextPrefab, _statTextPosition.transform);
            _itemDiscription.text = _item.Description;
            _priceText.text = "÷ена " + _item.Price.ToString();
        }
    }

    public void RemoveItemFromInventory()
    {
        if (_currentSlot != null)
        {
            InventorySlot slot = _currentSlot.GetComponent<InventorySlot>();

            slot.RemoveItem(slot.Amount);
            _removeInventoryItem.gameObject.SetActive(false);
            _removeInventoryItem.onClick.RemoveListener(() => slot.RemoveItem(slot.Amount));

            HideInfo();
        }
    }

    public void HideInfo()
    {
        _item = null;
        //_currentSlot = null;
        _icon.color = new Color(1, 1, 1, 0);
        _icon.sprite = null;
        _itemName.text = "";
        _itemType.text = "";
        _itemDiscription.text = "";
        _priceText.text = "";
        _statTextPosition.DestroyAllChild();
    }

    private void UseItem()
    {
        if (_currentSlot.Item != null)
        {
            _currentSlot.UseItem(_equipment, _inventory);

            _removeInventoryItem.gameObject.SetActive(false);
            _use.interactable = false;
            _use.onClick.RemoveListener(UseItem);

        }

        if (_currentSlot.IsEmpty == true)
        {
            HideInfo();
        }
    }

    private void RemoveEquipItemToInventory()
    {
        if (_currentSlot != null)
        {
            if (_currentSlot.TryGetComponent(out EquipmentSlot slot))
            {
                _inventory.AddItem(_item, 1);

                HeroStats.Instance.SumStats(-1, slot.Item.Armor, slot.Item.MinDamage, slot.Item.MaxDamage, slot.Item.Strength, slot.Item.Agility, slot.Item.Vitality, slot.Item.MaxHealth, slot.Item.AttackSpeed);
                slot.RemoveItem(1);

                HideInfo();
                _removeEquipItem.onClick.RemoveListener(RemoveEquipItemToInventory);
            }

        }
    }
}
