using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private int _damage;

    private Vector2 _direction;

    void Start()
    {
        StartCoroutine(DestroyBullet());
    }

    void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime, Space.World);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if(damageable != null)
        {
            damageable.TakeDamage(_damage);
        }
        
        Destroy(gameObject);
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    private IEnumerator DestroyBullet()
    {
        float elapsedTime = 0f;
        while(elapsedTime < _lifeTime)
        {
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        Destroy(gameObject);
    }
}
