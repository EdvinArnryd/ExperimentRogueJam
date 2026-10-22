using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Player Player;
    public PlayerController PlayerController;
    [SerializeField] public WaveManager WaveManager;
    [SerializeField] public StatGenerator StatGenerator;
    [SerializeField] public PauseManager PauseManager;

    [Header("For Debugging")]
    [SerializeField] private Player defaultPlayer;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        if(PlayerToLoad.Player != null)
        {
            // Keep this as final solution
            Player = Instantiate(PlayerToLoad.Player);
            PlayerController = Player.GetComponent<PlayerController>();
        }
        else
        {
            // For debugging only
            Player = Instantiate(defaultPlayer);
            PlayerController = Player.GetComponent<PlayerController>();
        }
    }
}
