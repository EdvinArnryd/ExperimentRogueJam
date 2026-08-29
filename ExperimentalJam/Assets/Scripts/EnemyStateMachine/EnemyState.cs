using UnityEngine;

public abstract class EnemyState
{
    public abstract void Enter(EnemyStateMachine stateMachine);
    public abstract void Exit(EnemyStateMachine stateMachine);
    public abstract void UpdateState(EnemyStateMachine stateMachine);
}
