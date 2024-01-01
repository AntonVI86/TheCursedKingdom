using System.Collections;
using System.Collections.Generic;
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
}
