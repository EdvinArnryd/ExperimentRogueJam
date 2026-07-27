using UnityEditor;
using UnityEngine;

public class IdleState : State
{
    public override void Enter()
    {
        Debug.Log("Entered Idle");
    }

    public override void Exit()
    {
        Debug.Log("Exited Idle");
    }
}
