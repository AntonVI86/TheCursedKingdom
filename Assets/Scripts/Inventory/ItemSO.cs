using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSO : ScriptableObject
{
    [SerializeField] protected ItemType TypeOfItem;

    [SerializeField] private string _label;
    [SerializeField] private string _description;

    [SerializeField] private int _maxAmount;

    [SerializeField] private Sprite _icon;
    [SerializeField] private AudioClip _useSfx;

    [SerializeField] private bool _eatable;

    public string Label => _label;
    public string Description => _description;
    public int MaxAmount => _maxAmount;
    public Sprite Icon => _icon;
    public AudioClip UseSfx => _useSfx;
    public bool Eatable => _eatable;
    public ItemType IType => TypeOfItem;
}
public enum ItemType { Default, Food, Weapon, Quest}
