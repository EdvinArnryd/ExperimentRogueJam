using System;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private float _waveDuration = 60f;
    [SerializeField] List<EnemySpawner> _enemySpawners;

    [SerializeField] private int _waveCount = 1;

    public event Action<int> OnUpdateWaveCount;
    public event Action<float> OnNewWave;

    void Start()
    {
        StartNewWave();
    }

    private void StartNewWave()
    {
        _waveCount++;
        OnUpdateWaveCount?.Invoke(_waveCount);
        OnNewWave?.Invoke(_waveDuration);
    }
}
