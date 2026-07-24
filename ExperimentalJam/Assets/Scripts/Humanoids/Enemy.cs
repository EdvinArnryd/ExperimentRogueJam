using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;
    public void TakeDamage(int damage)
    {
        _health.LoseHealth(damage);
    }
}
