using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _startHealth;
    private int _currentHealth;
    public event Action<int> OnHealthUpdate;
    public event Action OnDeath;

    private BoxCollider2D _collider;

    void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
        _currentHealth = _startHealth;
        OnHealthUpdate?.Invoke(_currentHealth);
    }

    private void Die()
    {
        _collider.enabled = false;
        OnDeath?.Invoke();
    }

    public void LoseHealth(int damage)
    {
        _currentHealth -= damage;
        OnHealthUpdate?.Invoke(_currentHealth);
        if(_currentHealth <= 0)
        {
            Die();
        }
    }

    public void GainHealth(int heal)
    {
        _currentHealth += heal;
        OnHealthUpdate?.Invoke(_currentHealth);
    }

    public int GetHealth()
    {
        return _currentHealth;
    }
}
