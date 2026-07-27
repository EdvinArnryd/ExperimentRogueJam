using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputSystem_Actions _inputActions;
    private Vector2 _moveInput;

    [SerializeField] private float _speed = 5;

    // Dash
    [SerializeField] private float _dashSpeed = 10f;
    [SerializeField] private float _dashDuration = 0.4f;
    private bool _isDashing = false;


    void Awake()
    {
        _inputActions = new InputSystem_Actions();

        _inputActions.Player.Move.performed += OnMove;
        _inputActions.Player.Move.canceled += OnMove;

        _inputActions.Player.Dash.performed += OnDash;
        _inputActions.Player.Dash.canceled -= OnDash;
    }
    
    private void OnEnable()
    {
        _inputActions.Player.Enable();        
    }

    private void OnDisable()
    {
        _inputActions.Player.Disable();       
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector2 movement = new Vector2(_moveInput.x, _moveInput.y);

        transform.Translate(movement * _speed * Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if(_isDashing) return;
        StartCoroutine(Dash());
    }

    private IEnumerator Dash()
    {
        Vector2 direction = _moveInput.normalized;
        _isDashing = true;

        float elapsedTime = 0f;
        
        while(elapsedTime < _dashDuration)
        {
            elapsedTime += Time.deltaTime;

            transform.Translate(direction * _dashSpeed * Time.deltaTime);

            yield return null;
        }
        _isDashing = false;
    }
}
