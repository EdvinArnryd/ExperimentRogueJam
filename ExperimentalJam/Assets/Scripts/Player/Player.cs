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
        _weapon.Attack(transform, direction);
    }

    public void PickUpCoin()
    {
        _coins++;
    }
}
