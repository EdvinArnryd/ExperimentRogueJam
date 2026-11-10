using System;
using System.Collections;
using UnityEngine;

public class DashState : State
{
    public override void Enter(PlayerStateMachine stateMachine)
    {
        stateMachine.SetAnimation("Dash");
        stateMachine.GetPlayer().SetImmunity(true);
    }

    public override void Exit(PlayerStateMachine stateMachine)
    {
        stateMachine.GetPlayer().SetImmunity(false);
    }

    public override void UpdateState(PlayerStateMachine stateMachine)
    {
        if(!stateMachine.GetIsDashing())
        {
            stateMachine.ChangeState(stateMachine._runningState);
        }
    }

    private IEnumerator StartDashing(PlayerStateMachine stateMachine, float transition, float rotation)
    {
        float rotationDelta = rotation/transition;

        float timer = Time.time;
        while(Time.time - timer < transition)
        {
            stateMachine.transform.Rotate(0,0, rotationDelta * Time.deltaTime);
            yield return null;
        }
    }
}
