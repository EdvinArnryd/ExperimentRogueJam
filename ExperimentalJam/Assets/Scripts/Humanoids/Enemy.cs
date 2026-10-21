using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;
    [SerializeField] private int _collisionDamage = 1;
    [SerializeField] private DamageFlash _damageFlash;
    [SerializeField] private Pickup _coinPickup;
    [SerializeField] private Pickup _itemPickup;

    void Awake()
    {
        _health.OnDeath += SpawnPickup;
    }

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

    private Pickup GeneratePickup()
    {
        int random = Random.Range(1,10);
        switch(random)
        {
            case > 1:
                return _coinPickup;
            case 1:
                return _itemPickup;
            default:
                return _coinPickup;
        }
    } 
    
    private void SpawnPickup()
    {
        Instantiate(GeneratePickup(), transform.position, Quaternion.identity);
    }
}
