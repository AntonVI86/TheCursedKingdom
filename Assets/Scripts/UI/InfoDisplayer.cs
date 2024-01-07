using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoDisplayer : MonoBehaviour
{
    [SerializeField] private TMP_Text _message;
    [SerializeField] private Inventory _inventory;

    private void Start()
    {
        foreach (var slot in _inventory.Slots)
        {
            slot.InfoDispayed += OnMessageDisplayed;
        }
    }

    private void OnDisable()
    {
        foreach (var slot in _inventory.Slots)
        {
            slot.InfoDispayed -= OnMessageDisplayed;
        }
    }

    private void OnMessageDisplayed(string text)
    {
        _message.text = text;
        print(text);
        StartCoroutine(CountDown());
    }

    private IEnumerator CountDown()
    {
        yield return new WaitForSeconds(2f);
        _message.text = "";
    }
}
