using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _startHealth;
    private int _currentHealth;

    void Awake()
    {
        _currentHealth = _startHealth;
    }

    private void Die()
    {
        print($"{gameObject} Died.");
        Destroy(gameObject);
    }

    public void LoseHealth(int damage)
    {
        _currentHealth -= damage;
        if(_currentHealth <= 0)
        {
            Die();
        }
    }

    public void GainHealth(int heal)
    {
        _currentHealth += heal;
    }

    public int GetHealth()
    {
        return _currentHealth;
    }
}
