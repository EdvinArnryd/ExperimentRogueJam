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

    // [SerializeField] private int _waveToSpawnMedium = 3;
    // [SerializeField] private int _waveToSpawnHigh = 6;
    // [SerializeField] private int _waveToSpawnTank = 9; 

    void OnEnable()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        Enemy enemy = Instantiate(GenerateEnemy(), transform.position, Quaternion.identity);

        yield return new WaitForSeconds(_spawnSpeed);

        StartCoroutine(SpawnEnemies());
    }

    private Enemy GenerateEnemy()
    {
        Enemy enemyToSpawn = new Enemy();
        int waveCount = GameManager.Instance.WaveManager.GetWaveCount();

        switch (waveCount)
        {
            case < 3:
                enemyToSpawn = _baseEnemies[Random.Range(0, _baseEnemies.Count)];
                break;
            case < 6:
                enemyToSpawn = _mediumEnemies[Random.Range(0, _mediumEnemies.Count)];
                break;
            case < 9:
                enemyToSpawn = _highEnemies[Random.Range(0, _highEnemies.Count)];
                break;
            default:
                break;
        }
        
        return enemyToSpawn;
    }
}
