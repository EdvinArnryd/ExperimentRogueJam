using UnityEngine;

public class IdleState : State
{

    public override void Enter(PlayerStateMachine stateMachine)
    {
        stateMachine.SetAnimation("Idle");
    }

    public override void Exit(PlayerStateMachine stateMachine)
    {
        
    }

    public override void UpdateState(PlayerStateMachine stateMachine)
    {
        if(stateMachine.GetIsMoving())
        {
            stateMachine.ChangeState(stateMachine._runningState);
        }
    }
}
