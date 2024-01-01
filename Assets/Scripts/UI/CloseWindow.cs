using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseWindow : MonoBehaviour
{
    [SerializeField] private GameObject _window;

    private Button _closeButton;

    private void Awake()
    {
        _closeButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _closeButton.onClick.AddListener(OnCloseWindow);
    }

    private void OnDisable()
    {
        _closeButton.onClick.RemoveListener(OnCloseWindow);
    }

    private void OnCloseWindow()
    {
        _window.SetActive(false);
        SoundPlayer.Instance.PlayCloseSFX();
    }
}
