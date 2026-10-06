using TMPro;
using UnityEngine;

public class Currency : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private Player _player;

    void Start()
    {
        _player = GameManager.Instance.Player;

        _player.OnCoinsUpdate += UpdateCurrency;
    }

    private void UpdateCurrency(int coins)
    {
        _text.text = coins.ToString();
    }
}
