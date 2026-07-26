using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;

    private DamageFlash _damageFlash;

    void Start()
    {
        _damageFlash = GetComponent<DamageFlash>();
    }
    public void TakeDamage(int damage)
    {
        _health.LoseHealth(damage);
        _damageFlash.CallDamageFlasher();
    }
}
