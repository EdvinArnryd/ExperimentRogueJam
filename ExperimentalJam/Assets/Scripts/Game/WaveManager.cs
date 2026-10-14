using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private float _waveDuration = 60f;
    [SerializeField] private float _pauseDuration = 5f;
    [SerializeField] EnemySpawner[] _enemySpawners;

    [SerializeField] private int _waveCount = 0;

    public event Action<int> OnUpdateWaveCount;
    public event Action<float> OnNewWave;

    void Start()
    {
        StartNewWave();
    }

    private void StartNewWave()
    {
        _waveCount++;
        ActivateCurrentSpawners();
        OnUpdateWaveCount?.Invoke(_waveCount);
        OnNewWave?.Invoke(_waveDuration);
        StartCoroutine(TickWaveRoutine());
    }

    private IEnumerator TickWaveRoutine()
    {
        yield return new WaitForSeconds(_waveDuration);
        StartCoroutine(TickPauseRoutine());
    }

    private IEnumerator TickPauseRoutine()
    {
        DeactivateAllSpawners();
        yield return new WaitForSeconds(_pauseDuration);
        StartNewWave();
    }

    private void DeactivateAllSpawners()
    {
        foreach(EnemySpawner spawner in _enemySpawners)
        {
            spawner.gameObject.SetActive(false);
        }
    }

    private void ActivateCurrentSpawners()
    {
        for(int i = 0; i < _waveCount; i++)
        {
            if(i >= _enemySpawners.Length)
                return;
            _enemySpawners[i].gameObject.SetActive(true);
        }
    }
}
