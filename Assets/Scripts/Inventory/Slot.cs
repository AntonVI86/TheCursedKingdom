using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] protected Image _icon;
    [SerializeField] protected ItemSO _item;

    public bool _isEmpty = true;

    protected Button _button;

    public Image Icon => _icon;
    public ItemSO Item => _item;

    public bool IsEmpty => _isEmpty;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(() => OnSelect());
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(() => OnSelect());
    }

    public virtual void GetItem(ItemSO item, int amount)
    {
        _item = item;
        Show(item);
    }

    public virtual void NullifySlotData()
    {
        _item = null;
        _isEmpty = true;
        _icon.color = new Color(1, 1, 1, 0);
        _icon.sprite = null;
    }

    public virtual void RemoveItem(int value)
    {
        
    }

    public virtual void UseItem(Equipment equipment, Inventory inventory)
    {
        
    }

    public virtual void Show(ItemSO item)
    {
        _icon.sprite = item.Icon;
        _icon.color = new Color(1, 1, 1, 1);
    }

    public virtual void OnSelect()
    {

    }
}
