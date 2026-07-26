using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;

    private int _maxHealth;

    void Start()
    {
        _maxHealth = _health.GetHealth();
        _health.OnHealthUpdate += UpdateHealthBar;
    }

    private void UpdateHealthBar(int health)
    {
        _slider.value = (float)health / (float)_maxHealth;
    }

}
