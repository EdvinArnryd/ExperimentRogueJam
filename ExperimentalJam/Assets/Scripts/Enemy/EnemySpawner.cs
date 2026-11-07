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

    [SerializeField] private int _waveToSpawnMedium = 3;
    [SerializeField] private int _waveToSpawnHigh = 6;
    [SerializeField] private int _waveToSpawnTank = 9; 

    void OnEnable()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        Enemy enemy = Instantiate(_tankEnemy, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(_spawnSpeed);

        StartCoroutine(SpawnEnemies());
    }
/*
    private Enemy GenerateEnemy()
    {
        Enemy enemyToSpawn;
        int waveCount = GameManager.Instance.WaveManager.GetWaveCount();

        switch (waveCount)
        {
            case < _waveToSpawnMedium:
                break;
            case < _waveToSpawnHigh:
                break;
            case < _waveToSpawnTank:
                break;
            default:
        }
        
        return enemyToSpawn;
    }
    */
}
