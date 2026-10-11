using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AttackIndicator : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] Slider _slider;

    void Start()
    {
        GameManager.Instance.Player.OnAttackCooldown += IndicateAttack;
    }

    private void IndicateAttack(float cooldown)
    {
        StartCoroutine(IndicateAttackRoutine(cooldown));
    }

    private IEnumerator IndicateAttackRoutine(float cooldown)
    {
        _slider.value = 1;

        float reduceSlider = _slider.value / cooldown;

        float timer = Time.time;
        while(Time.time - timer < cooldown)
        {
            _slider.value -= reduceSlider * Time.deltaTime;
            yield return null;
        }
    }
}
