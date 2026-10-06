using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Player _target;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Character _character;

    // Components
    private Health _health;

    // Character
    private bool _isLeft = false;
    private bool _isRight = true;

    void Start()
    {
        _health = GetComponent<Health>();
        _health.OnDeath += EnemyDeath;

        _agent.updateRotation = false;
        _agent.updateUpAxis = false;

        _target = GameManager.Instance.Player;
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

    private void EnemyDeath()
    {
        _agent.isStopped = true;
    }
}
