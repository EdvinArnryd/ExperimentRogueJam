using System.Diagnostics;
using UnityEngine;

public class RotatingProjectile : MonoBehaviour
{
    [SerializeField] private float _rotation;

    void Update()
    {
        transform.Rotate(0,0, _rotation * Time.deltaTime);
    }
}
