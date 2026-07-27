using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private int _damage;

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
}
