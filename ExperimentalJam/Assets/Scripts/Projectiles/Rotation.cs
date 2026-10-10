using System.Diagnostics;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float _rotation;

    void Update()
    {
        transform.Rotate(0,0, _rotation * Time.deltaTime);
    }
}
