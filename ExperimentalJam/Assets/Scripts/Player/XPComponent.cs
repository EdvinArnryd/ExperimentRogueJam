using System;
using UnityEngine;

public class XPComponent : MonoBehaviour
{
    
    [Header("XP")]
    [SerializeField] private float _baseXPThreshold = 10;
    [SerializeField] private float _maxXPIncrease = 1.4f;
    private float _currentXP = 0;
    private int _level = 1;

    public event Action<float, float> OnXPUpdated;
    public event Action<int> OnLevelUpdate;

    public void GainXP(float xp)
    {
        _currentXP += xp;
        if(_currentXP >= _baseXPThreshold)
        {
            _level++;

            _currentXP = _currentXP - _baseXPThreshold;
            _baseXPThreshold *= _maxXPIncrease;

            OnLevelUpdate?.Invoke(_level);
            GameManager.Instance.PauseManager.LevelUp();
            GameManager.Instance.StatGenerator.UpdateCards();
        }
        OnXPUpdated?.Invoke(_currentXP, _baseXPThreshold);
    }
}
