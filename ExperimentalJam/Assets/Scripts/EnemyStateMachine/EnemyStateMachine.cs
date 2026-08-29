using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private NavMeshAgent _agent;
    
    [SerializeField] private float _transitionTime = 0.25f;

    private EnemyState _currentState;

    public EnemyIdleState _idleState = new EnemyIdleState();
    public EnemyRunningState _runningState = new EnemyRunningState();

    private bool _isMoving;


    void Awake()
    {
        _currentState = _idleState;
        _currentState.Enter(this);
    }

    void Update()
    {
        _currentState?.UpdateState(this);
    }

    public void ChangeState(EnemyState newState)
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
