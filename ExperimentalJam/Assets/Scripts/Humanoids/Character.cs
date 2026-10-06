using System.Collections;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private ParticleSystem _particles;
    private Animator _animator;
    [SerializeField] private float _deathSpeed = 90f;
    [SerializeField] private float _maxRotation = 70f;
    void Awake()
    {
        _animator = GetComponent<Animator>();

        _health.OnDeath += DeathAnimation;
    }

    private void DeathAnimation()
    {
        StartCoroutine(DeathCoroutine());
    }

    private IEnumerator DeathCoroutine()
    {
        _particles.Play();
        _animator.CrossFade("Die", 0.1f);
        while(transform.eulerAngles.x < _maxRotation)
        {
            transform.Rotate(_deathSpeed * Time.deltaTime,0,0);
            yield return null;
        }

        Destroy(_health.gameObject);
    }
}
