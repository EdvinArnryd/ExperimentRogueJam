using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Projectile _projectilePrefab;

    public void Attack(Transform playerTransform, Vector2 direction)
    {
        float angle = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        Projectile projectile = Instantiate(_projectilePrefab, playerTransform.position, rotation);

        projectile.SetDirection(direction);
    }

}
