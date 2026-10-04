using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _spawnSpeed;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        Enemy enemy = Instantiate(_enemy, transform.position, Quaternion.identity);

        yield return new WaitForSeconds(_spawnSpeed);

        StartCoroutine(SpawnEnemies());
    }
}
