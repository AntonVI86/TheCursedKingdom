using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Items/Food Item", fileName = "NewFoodItem", order = 51)]
public class FoodItem : ItemSO
{
    [SerializeField] private float _healPower;

    public float HealPower => _healPower;

    private void Start()
    {
        TypeOfItem = ItemType.Food;
    }

    public new void ShowInfo(TMP_Text prefab, Transform point)
    {
        TMP_Text newStat = Instantiate(prefab, point);
        newStat.text = "Прибавка к здоровью " + _healPower.ToString();
    }
}
