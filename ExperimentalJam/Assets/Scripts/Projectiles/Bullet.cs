using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private int _damage;

    void Start()
    {
        StartCoroutine(DestroyBullet());
    }

    void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
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

    public void SetRotation(Quaternion quaternion)
    {
        transform.rotation = quaternion;
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
