using System.Collections;
using UnityEngine;

public class DashState : State
{

    private float _animationSpeed = 0.15f;
    private float _rotation = 15f;
    public override void Enter(PlayerStateMachine stateMachine)
    {
        stateMachine.SetAnimation("Dash");
        // stateMachine.StartCoroutine(StartDashing(stateMachine, _animationSpeed, _rotation));
    }

    public override void Exit(PlayerStateMachine stateMachine)
    {
        // stateMachine.StartCoroutine(StartDashing(stateMachine, _animationSpeed, -_rotation));
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
