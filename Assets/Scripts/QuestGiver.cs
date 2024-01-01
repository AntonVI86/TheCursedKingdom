using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private Image _bubble;
    [SerializeField] private TMP_Text _bubbleText;
    [SerializeField] private ItemSO _questItem;
    [SerializeField] private int _needAmount;
    [SerializeField] private Inventory _inventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out HeroStats stats))
        {
            _bubble.gameObject.SetActive(true);
            _bubbleText.text = $"Принеси мне {_needAmount} {_questItem.Label}!";

            foreach (var slot in _inventory.Slots)
            {
                if (slot.Item == _questItem && slot.Amount >= _needAmount)
                {
                    _bubbleText.text = $"Вот спасибо! Если найдешь еще, приноси!";

                    slot.RemoveItem(_needAmount);
                    return;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _bubble.gameObject.SetActive(false);
    }
}
