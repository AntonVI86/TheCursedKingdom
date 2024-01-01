using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private List<EnemyHealth> _enemies = new List<EnemyHealth>();
    
    [SerializeField] private HeroSpawner _heroSpawner;


    private void OnEnable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died += StartCountDown;            
        }
    }

    private void OnDisable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died -= StartCountDown;
        }
    }

    private void Start()
    {
        CreateEnemy();
    }

    private void CreateEnemy()
    {
        int index = Random.Range(0, _enemies.Count);

        _enemies[index].gameObject.SetActive(true);
        _enemies[index].transform.position = transform.position;
        _enemies[index].GetComponent<Enemy>().GetPlayer(_heroSpawner.GetHero());
        _enemies[index].ResetHealth();
    }

    private IEnumerator CountDown()
    {
        float time = Random.Range(3,8);
        yield return new WaitForSeconds(time);

        CreateEnemy();
    }

    private void StartCountDown()
    {
        StartCoroutine(CountDown());
    }
}
