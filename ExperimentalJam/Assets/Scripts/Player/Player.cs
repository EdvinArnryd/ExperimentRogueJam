using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;
    [SerializeField] private Weapon _weapon;
    private bool _damageImmune = false;
    
    [SerializeField] private DamageFlash _damageFlash;

    private int _coins;

    public event Action<int> OnCoinsUpdate; 
    private bool _readyToAttack = true;
    public event Action<float> OnAttackCooldown;

    public Stats _stats;

    void Awake()
    {
        _stats = GetComponent<Stats>();
    }

    public void TakeDamage(int damage)
    {
        if(_damageImmune) return;
        _health.LoseHealth(damage);

        _damageFlash.CallDamageFlasher();

        StartCoroutine(DamageImmunityCooldown());
    }

    private IEnumerator DamageImmunityCooldown()
    {
        _damageImmune = true;

        float elapsedTime = 0;
        while(elapsedTime < _damageFlash.GetFlashTime())
        {
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        _damageImmune = false;
    }

    public void Attack(Vector2 direction)
    {
        if(_readyToAttack)
        {
            OnAttackCooldown?.Invoke(_stats.GetStat(StatModifier.COOLDOWN));
            
            _weapon.Attack(transform, direction);

            StartCoroutine(AttackCooldownRoutine());
        }
    }
    
    private IEnumerator AttackCooldownRoutine()
    {
        _readyToAttack = false;

        yield return new WaitForSeconds(_stats.GetStat(StatModifier.COOLDOWN));

        _readyToAttack = true;
    }

    public void AddCoin(int coins)
    {
        _coins += coins;
        OnCoinsUpdate?.Invoke(_coins);
    }

    public Stats GetStats()
    {
        return _stats;
    }
}
