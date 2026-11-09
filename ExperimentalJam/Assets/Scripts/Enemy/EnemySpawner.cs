using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnSpeed;

    [SerializeField] private List<Enemy> _baseEnemies;
    [SerializeField] private List<Enemy> _mediumEnemies;
    [SerializeField] private List<Enemy> _highEnemies;
    [SerializeField] private Enemy _tankEnemy;

    private List<Enemy> _enemyPool = new List<Enemy>();

    void Awake()
    {
        AddEnemiesToPool(_baseEnemies);
    }

    void Start()
    {
        GameManager.Instance.WaveManager.OnUpdateWaveCount += UpdateEnemyPool;
    }

    void OnEnable()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        Instantiate(GenerateEnemy(), transform.position, Quaternion.identity);

        yield return new WaitForSeconds(_spawnSpeed);

        StartCoroutine(SpawnEnemies());
    }

    private Enemy GenerateEnemy()
    {
        return _enemyPool[Random.Range(0, _enemyPool.Count)];
    }

    private void UpdateEnemyPool(int waveCount)
    {
        switch (waveCount)
        {
            case 4:
                AddEnemiesToPool(_mediumEnemies);
                break;
            case 8:
                AddEnemiesToPool(_highEnemies);
                break;
            case 12:
                _enemyPool.Add(_tankEnemy);
                break;
            default:
                break;
        }
    }

    private void AddEnemiesToPool(List<Enemy> newEnemies)
    {
        foreach(Enemy enemy in newEnemies)
        {
            _enemyPool.Add(enemy);
        }
    }

    
}
