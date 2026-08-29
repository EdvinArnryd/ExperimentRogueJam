using UnityEngine;

public class EnemyIdleState : EnemyState
{
    public override void Enter(EnemyStateMachine stateMachine)
    {
        stateMachine.SetAnimation("Idle");
    }

    public override void Exit(EnemyStateMachine stateMachine)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(EnemyStateMachine stateMachine)
    {
        /*
        if(Player isInRange)
        {
            ChasePlayer();
            stateMachine.ChangeState(stateMachine._runningState);
        }

        */
    }
}
