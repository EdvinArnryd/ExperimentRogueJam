using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Player Player;
    public PlayerController PlayerController;
    [SerializeField] public WaveManager WaveManager;
    [SerializeField] public StatGenerator StatGenerator;
    [SerializeField] public PauseManager PauseManager;

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

        Player = Instantiate(PlayerToLoad.Player);
        PlayerController = Player.GetComponent<PlayerController>();
    }
}
