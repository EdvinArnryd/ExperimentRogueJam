using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeathTransition : MonoBehaviour
{
    [SerializeField] private float _transitionSpeed;
    [SerializeField] private float _finalAlpha;
    [SerializeField] private float _baseScale = 9f;
    [SerializeField] private float _finalScale = 1f;

    [SerializeField] private TMP_Text _text;
    [SerializeField] private Image _background;
    [SerializeField] private GameObject _spotLight;   

    private Color _textColor;
    private Color _backgroundColor;

    void Awake()
    {
        _textColor = _text.color;
        _backgroundColor = _background.color;
    }

    void OnEnable()
    {
        StartCoroutine(StartTransitionRoutine());
    }

    private IEnumerator StartTransitionRoutine()
    {
        float increaseAlpha = _finalAlpha/_transitionSpeed;
        float decreaseScale = _baseScale - _finalScale / _transitionSpeed;

        float timer = Time.unscaledTime;
        while(Time.unscaledTime - timer < _transitionSpeed)
        {
            _textColor.a += increaseAlpha * Time.unscaledDeltaTime;
            _backgroundColor.a += increaseAlpha * Time.unscaledDeltaTime;

            _text.color = _textColor;
            _background.color = _backgroundColor;

            //Scale
            _spotLight.transform.localScale -= new Vector3(decreaseScale * Time.unscaledDeltaTime, decreaseScale * Time.unscaledDeltaTime, 0);

            yield return null;
        }
    }
}
