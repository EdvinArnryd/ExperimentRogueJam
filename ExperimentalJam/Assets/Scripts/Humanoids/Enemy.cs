using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;
    [SerializeField] private int _collisionDamage = 1;

    public void TakeDamage(int damage)
    {
        _health.LoseHealth(damage);
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        Player _collidingPlayer = collider.gameObject.GetComponent<Player>();

        if(_collidingPlayer != null)
        {
            _collidingPlayer.TakeDamage(_collisionDamage);
            print("Taking Damage");
        }
    }
}
