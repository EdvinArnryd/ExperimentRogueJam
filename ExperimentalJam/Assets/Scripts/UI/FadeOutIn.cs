using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutIn : MonoBehaviour
{
    [SerializeField, Range(-1,1)] private int _fadeOut;
    [SerializeField] private float _alpha = 1f;
    [SerializeField] private float _duration = 0.5f;

    private Image _image;
    private Color _color;
    void Start()
    {
        _image = GetComponent<Image>();
        _color = _image.color;
        _color.a = _alpha;

        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        float reduceAmount = 1 / _duration;
        float timer = Time.time;

        while(Time.time - timer < _duration)
        {
            _color.a += reduceAmount * Time.deltaTime * _fadeOut;
            _image.color = _color;

            yield return null;
        }
    }
}
