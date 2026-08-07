using UnityEngine;

public class IdleState : State
{

    public override void Enter(StateMachine stateMachine)
    {
        stateMachine.SetAnimation("Idle");
    }

    public override void Exit(StateMachine stateMachine)
    {
        
    }

    public override void UpdateState(StateMachine stateMachine)
    {
        if(stateMachine.GetIsMoving())
        {
            stateMachine.ChangeState(stateMachine._runningState);
        }
    }
}
