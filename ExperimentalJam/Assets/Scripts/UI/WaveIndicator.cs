using System.Collections;
using TMPro;
using UnityEngine;

public class WaveIndicator : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _visibleDuration;
    [SerializeField] private float _fadeDuration;

    private Color _color;
    void Start()
    {
        GameManager.Instance.WaveManager.OnUpdateWaveCount += PopUpWaveNumber;

        _color = _text.color;
    }

    private void PopUpWaveNumber(int waveNumber)
    {
        _text.text = waveNumber.ToString();
        
        StartCoroutine(FadeInNumberRoutine());
    }

    private IEnumerator FadeInNumberRoutine()
    {
        float alphaReduction = 1f / _fadeDuration;

        float timer = Time.time;
        while(Time.time - timer < _fadeDuration)
        {
            _color.a += alphaReduction * Time.deltaTime;
            _text.color = _color;

            yield return null;
        }

        StartCoroutine(PopUpWaveNumberRoutine());
    }

    private IEnumerator PopUpWaveNumberRoutine()
    {
        yield return new WaitForSeconds(_visibleDuration);

        StartCoroutine(FadeOutNumberRoutine());
    }

    private IEnumerator FadeOutNumberRoutine()
    {
        float alphaReduction = 1f / _fadeDuration;

        float timer = Time.time;
        while(Time.time - timer < _fadeDuration)
        {
            _color.a -= alphaReduction * Time.deltaTime;
            _text.color = _color;

            yield return null;
        }
    }
    
}
