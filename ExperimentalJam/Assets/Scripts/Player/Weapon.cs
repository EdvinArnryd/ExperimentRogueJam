using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _coolDown = 1;
    [SerializeField] private float _size = 1;


    [SerializeField] private GameObject _weaponPrefab;

    public void Attack(Vector2 direction)
    {
        // Instantiate(_weaponPrefab, world, direction);
    }
}
