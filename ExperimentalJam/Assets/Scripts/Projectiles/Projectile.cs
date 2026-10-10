using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Alive Variables")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private int _damage;
    [SerializeField] private bool _isPlayerProjectile;

    [Header("Projectile Dead Variables")]
    [SerializeField] private float _shrinkTime;
    private SpriteRenderer _sprite;
    private Color _color;
    private BoxCollider2D _collider;

    private Vector2 _direction;

    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _color = _sprite.color;
        _collider = GetComponent<BoxCollider2D>();
        StartCoroutine(DestroyProjectile());
    }

    void Update()
    {
        transform.Translate(_direction * _moveSpeed * Time.deltaTime, Space.World);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(_isPlayerProjectile && collision.gameObject.CompareTag("Player"))
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

    private IEnumerator DestroyProjectile()
    {
        float elapsedTime = 0f;
        while(elapsedTime < _lifeTime)
        {
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        StartCoroutine(FadeOutProjectile());
    }

    private IEnumerator FadeOutProjectile()
    {
        _collider.enabled = false;
        float timer = Time.time;

        float shrinkAmount = 1f / _shrinkTime;
        float shrinkSpeed = transform.localScale.magnitude / _shrinkTime;
        float slowAmount = _moveSpeed / _shrinkTime;

        while(Time.time - timer < _shrinkTime)
        {
            _moveSpeed -= slowAmount * Time.deltaTime;
            _color.a -= shrinkAmount * Time.deltaTime;
            _sprite.color = _color;
            transform.localScale = Vector3.MoveTowards(
            transform.localScale,
            Vector3.zero,
            shrinkSpeed * Time.deltaTime
        );
            yield return null;
        }
        Destroy(gameObject);
    }
}
