using System;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private PlayerController _playerController;
    
    [SerializeField] private float _transitionTime = 0.25f;

    private State _currentState;

    public IdleState _idleState = new IdleState();
    public RunningState _runningState = new RunningState();

    private bool _isMoving;


    void Awake()
    {
        _playerController.IsMoving += IsMoving;

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

    public void SetAnimation(String animationState)
    {
        _anim.CrossFade(animationState, _transitionTime);
    }
}
