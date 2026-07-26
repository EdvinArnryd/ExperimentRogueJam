using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private Health _health;
    [SerializeField] private int _collisionDamage = 1;

    // Player References
    private Player _collidingPlayer;
    private bool _isCollidingPlayer;

    public void TakeDamage(int damage)
    {
        _health.LoseHealth(damage);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        _collidingPlayer = collision.gameObject.GetComponent<Player>();

        if(_collidingPlayer != null)
        {
            _isCollidingPlayer = true;
            _collidingPlayer.TakeDamage(_collisionDamage);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(_collidingPlayer != null)
        {
            _isCollidingPlayer = false;
            _collidingPlayer = null;
        }
    }
}
