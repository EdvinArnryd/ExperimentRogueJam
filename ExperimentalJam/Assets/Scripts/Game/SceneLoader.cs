using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }

    [SerializeField] private string _menuScene = "MenuScene";
    [SerializeField] private string _gameScene = "GameScene";

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
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(_menuScene);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(_gameScene);
    }
}
