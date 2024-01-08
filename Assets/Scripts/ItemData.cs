using UnityEngine;

public class ItemData : MonoBehaviour
{
    public ItemSO[] Items;

    public static ItemData Instance;

    private void Awake()
    {
        Instance = null;

        if (Instance == null)
        {
            Instance = this;
        }
    }
}
