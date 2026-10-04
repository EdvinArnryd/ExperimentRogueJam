using UnityEngine;
using UnityEngine.AI;

public class ChasePlayer : MonoBehaviour
{
    private Player _target;
    [SerializeField] private NavMeshAgent _agent;

    void Start()
    {
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;

        _target = GameManager.Instance._player;
    }
    // Update is called once per frame
    void Update()
    {
        _agent.SetDestination(_target.transform.position);
    }
}
