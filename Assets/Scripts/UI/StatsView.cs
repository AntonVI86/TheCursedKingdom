using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsView : MonoBehaviour
{
    [SerializeField] private TMP_Text _level;
    [SerializeField] private TMP_Text _armor;
    [SerializeField] private TMP_Text _maxHealth;
    [SerializeField] private TMP_Text _strength;
    [SerializeField] private TMP_Text _agility;
    [SerializeField] private TMP_Text _vitality;

    [SerializeField] private TMP_Text _damage;
    [SerializeField] private TMP_Text _attackSpeed;

    public static StatsView Instance;

    private void Awake()
    {
        Instance = null;

        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        UpdateViewStats();
    }

    public void UpdateViewStats()
    {
        _level.text = "������� " + HeroStats.Instance.Level.ToString();
        _armor.text = "������ " + HeroStats.Instance.Armor.ToString();
        _maxHealth.text = "����.�������� " + HeroStats.Instance.MaxHealth.ToString();
        _strength.text = "���� " + HeroStats.Instance.Strength.ToString();
        _agility.text = "�������� " + HeroStats.Instance.Agility.ToString();
        _vitality.text = "������������ " + HeroStats.Instance.Vitality.ToString();

        _damage.text = "���� " + HeroStats.Instance.MinDamage.ToString() + " - " + HeroStats.Instance.MaxDamage.ToString();
        _attackSpeed.text = "�������� ����� " + HeroStats.Instance.TimeToNewAttack.ToString();
    }
}
