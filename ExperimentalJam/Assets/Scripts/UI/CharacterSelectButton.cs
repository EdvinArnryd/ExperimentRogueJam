using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterSelectButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private String _idleAnimation = "Idle";
    [SerializeField] private String _frame = "Frame";
    [SerializeField] private float _transitionTime = 0.15f;
    [SerializeField] private Animator _anim;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _anim.CrossFade(_idleAnimation, _transitionTime);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _anim.CrossFade(_frame, _transitionTime);
    }
}
