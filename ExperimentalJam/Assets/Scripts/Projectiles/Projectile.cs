using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Alive Variables")]
    [SerializeField] private int _damage;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _size;
    [SerializeField] private float _duration;
    [SerializeField] private bool _isPlayerProjectile;

    [Header("Projectile Dead Variables")]
    [SerializeField] private float _shrinkTime;
    [SerializeField] private TrailRenderer _trail;
    private SpriteRenderer _sprite;
    private Color _color;
    private BoxCollider2D _collider;

    [SerializeField] private float _rotationSpeed = 1;
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
        _direction = Quaternion.Euler(
            0f,
            0f,
            _rotationSpeed * Time.deltaTime
        ) * _direction;
    }

    public void SetupProjectile(int damage, float speed, float size, float duration)
    {
        _damage = damage;
        _moveSpeed = speed;
        _size = size;
        _duration = duration;

        SetSize();
    }

    private void SetSize()
    {
        transform.localScale = new Vector3(_size, _size, _size);
        _trail.startWidth *= _size;
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
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    private IEnumerator DestroyProjectile()
    {
        float elapsedTime = 0f;
        while(elapsedTime < _duration)
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
        float trailShrinkAmount = _trail.startWidth / _shrinkTime;

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

            _trail.startWidth = Mathf.MoveTowards(
            _trail.startWidth,
            0f,
            trailShrinkAmount * Time.deltaTime
            );
            
            yield return null;
        }
        
        Destroy(gameObject);
    }
}
