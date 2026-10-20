using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;
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
    
    [Header("Stat Sprites")]
    [SerializeField] Sprite _cooldownSprite;
    [SerializeField] Sprite _damageSprite;
    [SerializeField] Sprite _durationSprite;
    [SerializeField] Sprite _sizeSprite;
    [SerializeField] Sprite _speedSprite;

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

    private (StatModifier stat, float statBaseMultiplier, string type, Sprite sprite) GenerateStat(StatModifier state)
    {
        StatModifier stat;
        float statBaseMultiplier;
        string type;
        Sprite sprite;

        switch(state)
        {
            case StatModifier.COOLDOWN:
                stat = StatModifier.COOLDOWN;
                statBaseMultiplier = _cooldownBase;
                type = "Cooldown";
                sprite = _cooldownSprite;
                break;
            case StatModifier.DAMAGE:
                stat = StatModifier.DAMAGE;
                statBaseMultiplier = _damageBase;
                type = "Damage";
                sprite = _damageSprite;
                break;
            case StatModifier.DURATION:
                stat = StatModifier.DURATION;
                statBaseMultiplier = _durationBase;
                type = "Duration";
                sprite = _durationSprite;
                break;
            case StatModifier.SIZE:
                stat = StatModifier.SIZE;
                statBaseMultiplier = _sizeBase;
                type = "Size";
                sprite = _sizeSprite;
                break;
            case StatModifier.SPEED:
                stat = StatModifier.SPEED;
                statBaseMultiplier = _speedBase;
                type = "Speed";
                sprite = _speedSprite;
                break;
            default:
                stat = StatModifier.SPEED;
                statBaseMultiplier = 1;
                type = "Undefined";
                sprite = _cooldownSprite;
                break;
        }

        return (stat, statBaseMultiplier, type, sprite);
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
    
    private List<StatModifier> GenerateStatList()
    {
        List<StatModifier> list =  new List<StatModifier>();
        foreach(StatModifier type in Enum.GetValues(typeof(StatModifier)))
        {
            list.Add(type);
        }

        return list;
    }

    private StatModifier GetRandomStatModifier(List<StatModifier> list)
    {
        int random = Random.Range(0, list.Count);
        StatModifier stat = list[random];
        list.Remove(stat);
        return stat;
    } 

    public void UpdateCards()
    {
        List<StatModifier> statList = GenerateStatList();
        foreach(Card card in _cards)
        {
            var currentStatType = GetRandomStatModifier(statList);
            var stat = GenerateStat(currentStatType);

            var rarity = GenerateRarity();

            card.SetCardValues(rarity.color, stat.type, stat.stat, stat.statBaseMultiplier * rarity.multiplier, stat.sprite);
        }
    }
}
