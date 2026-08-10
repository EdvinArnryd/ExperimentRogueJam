using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class RunningState : State
{
    public override void Enter(PlayerStateMachine stateMachine)
    {
        stateMachine.SetAnimation("Run");
    }

    public override void Exit(PlayerStateMachine stateMachine)
    {
        
    }

    public override void UpdateState(PlayerStateMachine stateMachine)
    {
        if(!stateMachine.GetIsMoving())
        {
            stateMachine.ChangeState(stateMachine._idleState);
        }
    }
}
