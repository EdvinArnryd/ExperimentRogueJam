using UnityEngine;
using UnityEngine.EventSystems;

public class LevelButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string _sceneToLoad;

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneLoader.Instance.LoadSpecificScene(_sceneToLoad);
    }
}
