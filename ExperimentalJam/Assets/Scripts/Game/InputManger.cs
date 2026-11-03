using UnityEngine;

public class InputManger : MonoBehaviour
{
    private InputSystem_Actions _inputActions;

    void Awake()
    {
        _inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        _inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Player.Disable();
        _inputActions.UI.Disable();
    }

    public InputSystem_Actions GetInputActions()
    {
        return _inputActions;
    }

    public void EnablePlayerMap()
    {
        _inputActions.Player.Enable();
        _inputActions.UI.Disable();
    }

    public void EnableUIMap()
    {
        _inputActions.Player.Disable();
        _inputActions.UI.Enable();
    }
}
