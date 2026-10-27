using System;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject _levelUpMenu;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _deathMenu;
    [SerializeField] private GameObject _gameplayUI;

    public event Action<bool> OnPauseGame;
    public event Action<bool> OnStartGame;

    void Start()
    {
        StartGame();
    }

    private void PauseGame()
    {
        OnPauseGame?.Invoke(true);
        Time.timeScale = 0;
    }

    private void StartGame()
    {
        OnStartGame?.Invoke(false);
        Time.timeScale = 1;
        _deathMenu.SetActive(false);
        _gameplayUI.SetActive(true);
    }

    public void LevelUp()
    {
        PauseGame();
        _levelUpMenu.SetActive(true);
    }

    public void ExitLevelUp()
    {
        StartGame();
        _levelUpMenu.SetActive(false);
    }

    public void PlayerDied()
    {
        _deathMenu.SetActive(true);
        _gameplayUI.SetActive(false);
        PauseGame();
    }
}
