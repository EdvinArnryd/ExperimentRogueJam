using System;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private PlayerController _playerController;
    
    [SerializeField] private float _transitionTime = 0.25f;

    private State _currentState;

    public IdleState _idleState = new IdleState();
    public RunningState _runningState = new RunningState();
    public DashState _dashingState = new DashState();

    private bool _isMoving;
    private bool _isDashing;


    void Awake()
    {
        _playerController.IsMoving += IsMoving;
        _playerController.IsDashing += IsDashing;

        _currentState = _idleState;
        _currentState.Enter(this);
    }

    void Update()
    {
        _currentState?.UpdateState(this);
    }

    public void ChangeState(State newState)
    {
        if(_currentState == newState) return;

        _currentState?.Exit(this);

        _currentState = newState;

        _currentState.Enter(this);
    }

    private void IsMoving(bool value)
    {
        _isMoving = value;
    }

    public bool GetIsMoving()
    {
        return _isMoving;
    }

    private void IsDashing(bool value)
    {
        _isDashing = value;
    }

    public bool GetIsDashing()
    {
        return _isDashing;
    }

    public void SetAnimation(String animationState)
    {
        _anim.CrossFade(animationState, _transitionTime);
    }
}
