using UnityEngine;
using UnityEngine.UI;

public class StatBoostModifier : MonoBehaviour
{
    [SerializeField] private Button _purchaseButton;
    [SerializeField] private StatModifier _statModifier;
    [SerializeField] private bool _incrementWithWholeNum = false;

    private int _currentLevel = 0;

    void Start()
    {
        //Read what level the player has and set the _currentLevel to it.
    }
    
}
