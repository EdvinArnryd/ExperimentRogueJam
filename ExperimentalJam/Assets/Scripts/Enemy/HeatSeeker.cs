using UnityEngine;

public class HeatSeeker : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private float _speed;

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = (_target.transform.position - transform.position).normalized;
        transform.Translate(direction * _speed * Time.deltaTime);
    }
}
