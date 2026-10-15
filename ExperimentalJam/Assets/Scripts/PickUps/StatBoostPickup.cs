using UnityEngine;

public class StatBoostPickup : Pickup
{
    [SerializeField] private StatModifier _stat;
    [SerializeField] private float _value;

    public override void PickUp(Player player)
    {
        player.GetStats().ImproveStats(_stat, _value);

        DestroyPickup();
    }
}
