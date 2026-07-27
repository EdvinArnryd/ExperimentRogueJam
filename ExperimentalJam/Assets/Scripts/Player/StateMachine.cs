using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private State _currentState;

    void Awake()
    {
        _currentState = new IdleState();
    }
}
