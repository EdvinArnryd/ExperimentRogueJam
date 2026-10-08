using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private GameObject _menuToOpen;
    [SerializeField] private GameObject _menuToClose;

    public void ChangeMenu()
    {
        _menuToOpen.SetActive(true);
        _menuToClose.SetActive(false);
    }
}
