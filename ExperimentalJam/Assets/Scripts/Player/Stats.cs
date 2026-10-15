using UnityEngine;

public class Stats : MonoBehaviour
{
    public enum StatModifier
    {
        DAMAGE,
        SPEED,
        SIZE,
        DURATION,
        COOLDOWN
    }

    [SerializeField] private int _damage = 1;
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _size = 1;
    [SerializeField] private float _duration = 1;
    [SerializeField] private float _cooldown = 1;

    public void ImproveStats(StatModifier modifier, float value)
    {
        switch(modifier)
        {
            case StatModifier.DAMAGE:
                _damage += Mathf.RoundToInt(value);
                break;
            case StatModifier.SPEED:
                _speed += value;
                break;
            case StatModifier.SIZE:
                _size += value;
                break;
            case StatModifier.DURATION:
                _duration += value;
                break;
            case StatModifier.COOLDOWN:
                _cooldown += value;
                break;
            default:
                break;
        }
    }

    public float GetStat(StatModifier modifier)
    {
        switch(modifier)
        {
            case StatModifier.DAMAGE:
                return _damage;
            case StatModifier.SPEED:
                return _speed;
            case StatModifier.SIZE:
                return _size;
            case StatModifier.DURATION:
                return _duration;
            case StatModifier.COOLDOWN:
                return _cooldown;
            default:
                return 1;
        }
    }
}
