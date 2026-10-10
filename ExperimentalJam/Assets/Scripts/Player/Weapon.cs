using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _coolDown = 1;
    [SerializeField] private float _size = 1;
    [SerializeField] private Sprite _weaponImage;
    [SerializeField] private Projectile _projectilePrefab;

    public void Attack(Transform playerTransform, Vector2 direction)
    {
        Projectile bullet = Instantiate(_projectilePrefab, playerTransform.position, Quaternion.identity);

        bullet.SetDirection(direction);
    }
}
