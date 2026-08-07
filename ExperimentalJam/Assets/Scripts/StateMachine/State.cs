using UnityEngine;

public abstract class State
{
    public abstract void Enter(StateMachine stateMachine);
    public abstract void Exit(StateMachine stateMachine);
    public abstract void UpdateState(StateMachine stateMachine);
}
