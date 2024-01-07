using UnityEngine;

public class ActivateInventory : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Equipment _equipment;

    private void Awake()
    {
        _inventory.GetSlots();
        _equipment.GetSlots();
    }
}
