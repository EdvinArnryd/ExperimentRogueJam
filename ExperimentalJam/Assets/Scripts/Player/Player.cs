using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;
    public void TakeDamage(int damage)
    {
        _health.LoseHealth(damage);
    }
}
