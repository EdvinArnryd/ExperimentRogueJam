using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float _animationSpeed = 0.5f;
    [SerializeField] private float _animationAngle = 20;
    [SerializeField] private float _animationGrowth = 1.1f;

    private Quaternion _baseRotation;
    private Vector3 _baseVectorScale;

    void Start()
    {
        _baseRotation = transform.rotation;
        _baseVectorScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine(AnimateCardRoutine());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartCoroutine(ReverseAnimateCardRoutine());
    }

    private IEnumerator AnimateCardRoutine()
    {
        float angleIncrement = _animationAngle / _animationSpeed;
        float growthIncrement = _animationGrowth / _animationSpeed;

        float timer = Time.unscaledTime;
        while(Time.unscaledTime - timer < _animationSpeed)
        {
            transform.localScale = transform.localScale + new Vector3(growthIncrement * Time.unscaledDeltaTime, growthIncrement * Time.unscaledDeltaTime, 0);

            transform.Rotate(0,0, angleIncrement * Time.unscaledDeltaTime);

            yield return null;
        }
    }

    private IEnumerator ReverseAnimateCardRoutine()
    {
        float angleIncrement = _animationAngle / _animationSpeed;
        float growthIncrement = _animationGrowth / _animationSpeed;

        float timer = Time.unscaledTime;
        while(Time.unscaledTime - timer < _animationSpeed)
        {
            transform.localScale = transform.localScale - new Vector3(growthIncrement * Time.unscaledDeltaTime, growthIncrement * Time.unscaledDeltaTime, 0);

            transform.Rotate(0,0, -angleIncrement * Time.unscaledDeltaTime);

            yield return null;
        }

        transform.rotation = _baseRotation;
        transform.localScale = _baseVectorScale;
    }
}
