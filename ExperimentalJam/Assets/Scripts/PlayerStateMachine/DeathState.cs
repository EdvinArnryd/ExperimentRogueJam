using UnityEngine;

public class DeathState : State
{
    public override void Enter(PlayerStateMachine stateMachine)
    {
        GameManager.Instance.PauseManager.PlayerDied();
        stateMachine.SetAnimation("Death");
    }

    public override void Exit(PlayerStateMachine stateMachine)
    {
        
    }

    public override void UpdateState(PlayerStateMachine stateMachine)
    {
        
    }
}
