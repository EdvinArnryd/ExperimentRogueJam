using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DashIndicator : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] Slider _slider;
    void Start()
    {
       GameManager.Instance.PlayerController.OnDashCooldown += IndicateDash; 
    }

    private void IndicateDash(float cooldown)
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
