using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _levelText;

    private XPComponent _xpComponent;

    void Start()
    {
        _xpComponent = GameManager.Instance.Player.GetXPComponent();

        _xpComponent.OnXPUpdated += UpdateSliderXP;
        _xpComponent.OnLevelUpdate += UpdateLevel;
    }

    private void UpdateSliderXP(float xp, float threshold)
    {
        _slider.value = xp / threshold;
    }

    private void UpdateLevel(int level)
    {
        _levelText.text = $"LV {level}";
    }
}
