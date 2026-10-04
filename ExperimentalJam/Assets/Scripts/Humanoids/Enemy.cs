using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;
    [SerializeField] private int _collisionDamage = 1;
    [SerializeField] private DamageFlash _damageFlash;

    public void TakeDamage(int damage)
    {
        _health.LoseHealth(damage);
        
        _damageFlash.CallDamageFlasher();
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        Player _collidingPlayer = collider.gameObject.GetComponent<Player>();

        if(_collidingPlayer != null)
        {
            _collidingPlayer.TakeDamage(_collisionDamage);
        }
    }
}
