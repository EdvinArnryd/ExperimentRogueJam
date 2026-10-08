using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterSelectButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string _idleAnimation = "Idle";
    [SerializeField] private string _frame = "Frame";
    [SerializeField] private float _transitionTime = 0.15f;
    [SerializeField] private Animator _anim;
    [SerializeField] private GameObject _imageGameObject;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _anim.CrossFade(_idleAnimation, _transitionTime);
        _imageGameObject.GetComponent<Image>().color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _anim.CrossFade(_frame, _transitionTime);
        _imageGameObject.GetComponent<Image>().color = Color.black;
    }
}
