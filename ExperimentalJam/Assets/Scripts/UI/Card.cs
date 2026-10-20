using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TMP_Text _title;
    [SerializeField] private TMP_Text _description;

    private StatModifier _statModifier;
    private float _statIncrease;
    private Image _image;
    
    void Awake()
    {
        _image = gameObject.GetComponent<Image>();
    }

    public void SetCardValues(Color color, string title, StatModifier modifier, float multiplier)
    {
        _image.color = color;
        _title.text = title;
        _description.text = "x " + multiplier.ToString();
        _statIncrease = multiplier;
        _statModifier = modifier;
    }

    public (StatModifier modifier, float multiplier) GetStatValues()
    {
        return (_statModifier, _statIncrease);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Instance.Player._stats.ImproveStats(_statModifier, _statIncrease);
        GameManager.Instance.PauseManager.ExitLevelUp();
    }
}
