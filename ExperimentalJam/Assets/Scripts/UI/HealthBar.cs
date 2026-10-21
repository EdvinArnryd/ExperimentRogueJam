using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private int _maxHealth;
    private Health _health;

    void Start()
    {
        _health = GameManager.Instance.Player.GetComponent<Health>();
        _maxHealth = _health.GetHealth();
        _health.OnHealthUpdate += UpdateHealthBar;
    }

    private void UpdateHealthBar(int health)
    {
        _slider.value = (float)health / (float)_maxHealth;
    }

}
