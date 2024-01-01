using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _amountText;
    [SerializeField] private ItemSO _item;
    [SerializeField] private int _amount;
    
    public bool _isEmpty = true;

    private Button _button;

    public ItemSO Item => _item;
    public int Amount => _amount;
    
    public bool IsEmpty => _isEmpty;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(UseItem);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(UseItem);
    }

    public void AddToAmount(int value)
    {
        _amount += value;
        _amountText.text = _amount.ToString();
    }

    public void GetItem(ItemSO item, int amount)
    {
        _item = item;
        _amount = amount;
        Show(item);
    }

    public void NullifySlotData()
    {
        _item = null;
        _amount = 0;
        _isEmpty = true;
        _icon.color = new Color(1, 1, 1, 0);
        _icon.sprite = null;
        _amountText.text = "";
    }

    public void RemoveItem(int value)
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

    public void UseItem()
    {
        if(_item != null)
        {
            if(_item.Eatable == true)
            {
                if (HeroStats.Instance.Heal(1))
                {
                    SoundPlayer.Instance.PlayOtherSound(_item.UseSfx);
                    RemoveItem(1);
                }
                else
                {
                    print("Максимальное здоровье");
                }                
            }
        }
    }
   
    private void Show(ItemSO item)
    {
        _icon.sprite = item.Icon;
        _icon.color = new Color(1,1,1,1);
        _amountText.text = _amount.ToString();
    }
}
