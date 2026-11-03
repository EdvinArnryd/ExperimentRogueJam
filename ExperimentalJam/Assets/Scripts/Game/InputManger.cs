using UnityEngine;

public class InputManger : MonoBehaviour
{
    [SerializeField] private InputSystem_Actions _inputActions;

    private void OnEnable()
    {
        _inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Player.Disable();
    }

    public InputSystem_Actions GetInputActions()
    {
        return _inputActions;
    }
}
