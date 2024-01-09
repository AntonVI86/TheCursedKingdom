using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    [SerializeField] private Button _takeButton;

    [SerializeField] private Inventory _chestInventory;
    [SerializeField] private Inventory _heroInventory;

    [SerializeField] private ItemSO _needItem;

    [SerializeField] private bool _isLocked;

    private InventorySlot _currentSlot;
    private ItemSO _item;

    private void OnEnable()
    {
        foreach (var slot in _chestInventory.Slots)
        {
            slot.Selected += OnSelected;
        }

        _takeButton.onClick.AddListener(TakeItem);
    }

    private void OnDisable()
    {
        foreach (var slot in _chestInventory.Slots)
        {
            slot.Selected -= OnSelected;
        }

        _takeButton.onClick.RemoveListener(TakeItem);
    }

    private void Start()
    {
        _chestInventory.AddItem(ItemData.Instance.Items[2], 1);
        _chestInventory.AddItem(ItemData.Instance.Items[4], 1);
    }

    private void OnSelected(ItemSO item, InventorySlot slot)
    {
        _item = item;
        _currentSlot = slot;
    }

    private void TakeItem()
    {
        if (_item != null)
        {
            _heroInventory.AddItem(_item, _currentSlot.Amount);
            _currentSlot.RemoveItem(_currentSlot.Amount);
            _item = null;
        }

        if(IsFullness() == false)
            _chestInventory.gameObject.SetActive(false);
    }

    private bool IsFullness()
    {
        int count = 0;
        foreach (var slot in _chestInventory.Slots)
        {
            if (slot.Item != null)
                count++;
        }

        if (count <= 0)
            return false;

        return true;
    }

    private bool HasNeedItem()
    {
        foreach (var slot in _heroInventory.Slots)
        {
            if (slot.Item == _needItem)
                return true;
        }

        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out HeroCollision hero))
        {
            if (HasNeedItem())
            {
                _isLocked = false;
            }
            else
            {
                print("Сундук закрыт! Нужен ключ!");
            }

            if(IsFullness() && _isLocked == false)
                _chestInventory.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HeroCollision hero))
        {
            _chestInventory.gameObject.SetActive(false);
        }
    }
}
