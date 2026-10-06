using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _shrinkTime;
    [SerializeField] private int _damage;
    [SerializeField] private bool _isPlayerBullet;

    private Vector2 _direction;

    private BoxCollider2D _collider;
    private Sprite _sprite;

    void Start()
    {
        _sprite = GetComponent<Sprite>();
        _collider = GetComponent<BoxCollider2D>();
        StartCoroutine(DestroyBullet());
    }

    void Update()
    {
        transform.Translate(_direction * _moveSpeed * Time.deltaTime, Space.World);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(_isPlayerBullet && collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if(damageable != null)
        {
            damageable.TakeDamage(_damage);
        }
        
        //Destroy(gameObject);
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

        StartCoroutine(FadeOutBullet());
    }

    private IEnumerator FadeOutBullet()
    {
        _collider.enabled = false;
        _moveSpeed = 1;
        float timer = Time.time;
        while(Time.time - timer < _shrinkTime)
        {
            transform.localScale -= transform.localScale * Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
