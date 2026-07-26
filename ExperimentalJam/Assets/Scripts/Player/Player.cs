using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;
    
    [SerializeField] private float _immunityCooldown = 1f;
    private bool _damageImmune = false;
    
    private DamageFlash _damageFlash;

    void Start()
    {
        _damageFlash = GetComponent<DamageFlash>();
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
        while(elapsedTime < _immunityCooldown)
        {
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        _damageImmune = false;
    }


}
