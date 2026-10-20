using System.Collections.Generic;
using UnityEngine;

public class StatGenerator : MonoBehaviour
{

    [Header("Cards")]
    [SerializeField] private List<Card> _cards;

    [Header("Stat Base Values")]
    [SerializeField] float _cooldownBase = -0.01f;
    [SerializeField] float _damageBase = 0.3f;
    [SerializeField] float _durationBase = 0.3f;
    [SerializeField] float _sizeBase = 0.3f;
    [SerializeField] float _speedBase = 0.3f;

    [Header("Color Picker")]
    [SerializeField] Color _commonColor;
    [SerializeField] Color _unCommonColor;
    [SerializeField] Color _rareColor;
    [SerializeField] Color _epicColor;
    [SerializeField] Color _legendaryColor;

    [Header("Rarity Multipliers")]
    [SerializeField] float _commonMultiplier = 1;
    [SerializeField] float _uncommonMultiplier = 1.5f;
    [SerializeField] float _rareMultiplier = 2.2f;
    [SerializeField] float _epicMultiplier = 3.3f;
    [SerializeField] float _legendaryMultiplier = 5;

    private (StatModifier stat, float statBaseMultiplier, string type) GenerateStat()
    {
        StatModifier stat;
        float statBaseMultiplier;
        string type;

        int random = Random.Range(1,6);
        switch(random)
        {
            case 1:
                stat = StatModifier.COOLDOWN;
                statBaseMultiplier = _cooldownBase;
                type = "Cooldown";
                break;
            case 2:
                stat = StatModifier.DAMAGE;
                statBaseMultiplier = _damageBase;
                type = "Damage";
                break;
            case 3:
                stat = StatModifier.DURATION;
                statBaseMultiplier = _durationBase;
                type = "Duration";
                break;
            case 4:
                stat = StatModifier.SIZE;
                statBaseMultiplier = _sizeBase;
                type = "Size";
                break;
            case 5:
                stat = StatModifier.SPEED;
                statBaseMultiplier = _speedBase;
                type = "Speed";
                break;
            default:
                stat = StatModifier.UNDEFINED;
                statBaseMultiplier = 1;
                type = "Undefined";
                break;
        }

        return (stat, statBaseMultiplier, type);
    }

    private (Rarity rarity, Color color, float multiplier) GenerateRarity()
    {
        Rarity rarity;
        Color color;
        float multiplier;
        
        int random = Random.Range(1,100);
        switch(random)
        {
            case >=60:
                rarity = Rarity.COMMON;
                color = _commonColor;
                multiplier = _commonMultiplier;
                break;
            case >=30:
                rarity = Rarity.UNCOMMON;
                color = _unCommonColor;
                multiplier = _uncommonMultiplier;
                break;
            case >=15:
                rarity = Rarity.RARE;
                color = _rareColor;
                multiplier = _rareMultiplier;
                break;
            case >=5:
                rarity = Rarity.EPIC;
                color = _epicColor;
                multiplier = _epicMultiplier;
                break;
            case >=1:
                rarity = Rarity.LEGENDARY;
                color = _legendaryColor;
                multiplier = _legendaryMultiplier;
                break;
            default:
                rarity = Rarity.UNDEFINED;
                color = Color.gray;
                multiplier = 1;
                break;
        }

        return (rarity, color, multiplier);
    }

    public void UpdateCards()
    {
        foreach(Card card in _cards)
        {
            var rarity = GenerateRarity();
            var stat = GenerateStat();

            card.SetCardValues(rarity.color, stat.type, stat.stat, stat.statBaseMultiplier * rarity.multiplier);
        }
    }
}
