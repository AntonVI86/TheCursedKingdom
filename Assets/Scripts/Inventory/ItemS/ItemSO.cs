using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSO : ScriptableObject
{
    [SerializeField] protected ItemType TypeOfItem;

    [SerializeField] private string _label;
    [SerializeField] private string _description;

    [SerializeField] private int _maxAmount;
    [SerializeField] private int _price;

    [SerializeField] private Sprite _icon;
    [SerializeField] private AudioClip _useSfx;

    [SerializeField] private bool _eatable;
    [SerializeField] private bool _isArmor;

    public string Label => _label;
    public string Description => _description;
    public int MaxAmount => _maxAmount;
    public int Price => _price;
    public Sprite Icon => _icon;
    public AudioClip UseSfx => _useSfx;
    public bool Eatable => _eatable;
    public bool IsArmor => _isArmor;
    public ItemType IType => TypeOfItem;
}
public enum ItemType { Head, Shoulders, Necklace, Cloak, Armor, Bracers, Gloves, Leggs, Fingers, Boots, RightHand, LeftHand, Belt, Food, Quest }
