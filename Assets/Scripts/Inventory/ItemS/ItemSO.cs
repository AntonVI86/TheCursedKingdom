using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemSO : ScriptableObject
{
    [SerializeField] protected ItemType TypeOfItem;
    [SerializeField] private int _itemID;

    [SerializeField] private string _label;
    [SerializeField] private string _description;

    [SerializeField] private int _maxAmount;
    [SerializeField] private int _price;

    [SerializeField] private Sprite _icon;
    [SerializeField] private AudioClip _useSfx;

    [SerializeField] private bool _eatable;
    [SerializeField] private bool _isArmor;

    [SerializeField] private int _strength;
    [SerializeField] private int _agility;
    [SerializeField] private int _vitality;
    [SerializeField] private int _armor;
    [SerializeField] private int _maxHealth;

    [SerializeField] private float _radius;
    [SerializeField] private float _minDamage;
    [SerializeField] private float _maxDamage;
    [SerializeField] private float _attackSpeed;

    public int ItemID => _itemID;
    public int Strength => _strength;
    public int Agility => _agility;
    public int Vitality => _vitality;
    public int Armor => _armor;
    public int MaxHealth => _maxHealth;

    public float Radius => _radius;
    public float MinDamage => _minDamage;
    public float MaxDamage => _maxDamage;
    public float AttackSpeed => _attackSpeed;

    public string Label => _label;
    public string Description => _description;
    public int MaxAmount => _maxAmount;
    public int Price => _price;
    public Sprite Icon => _icon;
    public AudioClip UseSfx => _useSfx;
    public bool Eatable => _eatable;
    public bool IsArmor => _isArmor;
    public ItemType IType => TypeOfItem;

    public void ShowInfo(TMP_Text prefab, Transform point)
    {
        if (_strength != 0)
        {
            TMP_Text newStat = Instantiate(prefab, point);
            newStat.text = "Сила " + _strength.ToString();
        }

        if (_agility != 0)
        {
            TMP_Text newStat = Instantiate(prefab, point);
            newStat.text = "Ловкость " + _agility.ToString();
        }

        if (_vitality != 0)
        {
            TMP_Text newStat = Instantiate(prefab, point);
            newStat.text = "Стойкость " + _vitality.ToString();
        }

        if (_armor != 0)
        {
            TMP_Text newStat = Instantiate(prefab, point);
            newStat.text = "Защита " + _armor.ToString();
        }

        if (_maxHealth != 0)
        {
            TMP_Text newStat = Instantiate(prefab, point);
            newStat.text = "Макс.здоровье " + _maxHealth.ToString();
        }

        if (_minDamage != 0)
        {
            TMP_Text newStat = Instantiate(prefab, point);
            newStat.text = "Макс/Мин атака " + _minDamage.ToString() + "/" + _maxDamage.ToString();
        }

        if (_attackSpeed != 0)
        {
            TMP_Text newStat = Instantiate(prefab, point);
            newStat.text = "Скорость " + _attackSpeed.ToString();
        }


    }
}
public enum ItemType { Head, Shoulders, Necklace, Cloak, Armor, Bracers, Gloves, Leggs, Fingers, Boots, RightHand, LeftHand, Belt, Food, Quest }
