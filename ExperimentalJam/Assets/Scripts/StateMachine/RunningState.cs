using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class RunningState : State
{
    public override void Enter(StateMachine stateMachine)
    {
        stateMachine.SetAnimation("Run");
    }

    public override void Exit(StateMachine stateMachine)
    {
        
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        if(!stateMachine.GetIsMoving())
        {
            stateMachine.ChangeState(stateMachine._idleState);
        }
    }
}
