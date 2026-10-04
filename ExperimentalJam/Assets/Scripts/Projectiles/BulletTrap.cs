using System.Collections;
using UnityEngine;

public class BulletTrap : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private GameObject _muzzle;

    [SerializeField] private float _bulletCooldown = 1f;
    void Start()
    {
        StartCoroutine(ShootBullets());
    }

    private IEnumerator ShootBullets()
    {
        float elapsedTime = 0f;
        
        Bullet bullet = Instantiate(_bulletPrefab, _muzzle.transform.position, Quaternion.identity);
        bullet.SetDirection(GetVector2Rotation());
        while(elapsedTime < _bulletCooldown)
        {
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        StartCoroutine(ShootBullets());
    }

    private Vector2 GetVector2Rotation()
    {
        Quaternion rotation = transform.rotation;

        Vector2 direction = rotation * Vector2.up;

        return direction;
    }
}
