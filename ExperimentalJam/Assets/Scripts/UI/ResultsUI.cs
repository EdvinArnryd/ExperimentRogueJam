using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultsUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _monsterText;
    [SerializeField] private TMP_Text _xpText;
    [SerializeField] private TMP_Text _goldText;

    private void OnEnable()
    {
        _monsterText.text = GameManager.Instance.GameResultsManager.GetMonsterKilled().ToString();
        _xpText.text = GameManager.Instance.GameResultsManager.GetXPGained().ToString();
        _goldText.text = GameManager.Instance.GameResultsManager.GetGoldGained().ToString();
    }
}
