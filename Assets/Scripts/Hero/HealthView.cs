using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private HeroSpawner _spawner;

    private List<Image> _hearts = new List<Image>();

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _hearts.Add(transform.GetChild(i).GetComponent<Image>());
        }    
    }

    private void OnEnable()
    {
        _spawner.GetHero().HealthValueChanged += OnChangeHealthValue;
    }

    private void OnDisable()
    {
        _spawner.GetHero().HealthValueChanged -= OnChangeHealthValue;
    }

    private void Start()
    {
        OnChangeHealthValue(_spawner.GetHero().CurrentHealth);
    }

    private void OnChangeHealthValue(int value)
    {
        foreach (var heart in _hearts)
        {
            heart.gameObject.SetActive(false);
        }

        for (int i = 0; i < _spawner.GetHero().CurrentHealth; i++)
        {
            _hearts[i].gameObject.SetActive(true);
        }
    }
}
