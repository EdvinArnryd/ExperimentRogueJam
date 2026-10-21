using Unity.Cinemachine;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Player _player;
    private CinemachineCamera _camera;
    void Start()
    {
        _player = GameManager.Instance.Player;
        _camera = GetComponent<CinemachineCamera>();
        _camera.Target.TrackingTarget = _player.transform;
    }
}
