using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Player _target;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Character _character;

    // Character
    private bool _isLeft = false;
    private bool _isRight = true;

    void Start()
    {
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;

        _target = GameManager.Instance._player;
    }

    void Update()
    {
        _agent.SetDestination(_target.transform.position);
        RotateCharacter();
    }

    private void RotateCharacter()
    {
        if(_agent.velocity.x > 0.01f && _isLeft)
        {
            _isRight = true;
            _isLeft = false;

            _character.transform.Rotate(0,180,0);
        }
        else if(_agent.velocity.x  < 0f && _isRight)
        {
            _isRight = false;
            _isLeft = true;
            _character.transform.Rotate(0,180,0);
        }
    }
}
