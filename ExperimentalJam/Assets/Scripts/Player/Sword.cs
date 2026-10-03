using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    void Update()
    {
        transform.Rotate(0, 0, -_rotationSpeed * Time.deltaTime);
    }
}
