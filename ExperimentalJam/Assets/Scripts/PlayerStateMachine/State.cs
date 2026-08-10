using UnityEngine;

public abstract class State
{
    public abstract void Enter(PlayerStateMachine stateMachine);
    public abstract void Exit(PlayerStateMachine stateMachine);
    public abstract void UpdateState(PlayerStateMachine stateMachine);
}
