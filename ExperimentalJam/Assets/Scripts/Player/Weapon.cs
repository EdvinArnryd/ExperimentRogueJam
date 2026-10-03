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
    [SerializeField] private Bullet _bulletPrefab;

    public void Attack(Transform playerTransform, Vector2 direction)
    {
        Bullet bullet = Instantiate(_bulletPrefab, playerTransform.position, Quaternion.identity);

        bullet.SetDirection(direction);
    }
}
