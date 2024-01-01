using UnityEngine;
using UnityEngine.UI;

public class WindowOpener : MonoBehaviour
{
    [SerializeField] private GameObject _window;

    private Button _openButton;

    private void Awake()
    {
        _openButton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _openButton.onClick.AddListener(OnOpenWindow);
    }

    private void OnDisable()
    {
        _openButton.onClick.RemoveListener(OnOpenWindow);
    }

    private void OnOpenWindow()
    {
        _window.SetActive(true);
        SoundPlayer.Instance.PlayOpenSFX();
    }
}
