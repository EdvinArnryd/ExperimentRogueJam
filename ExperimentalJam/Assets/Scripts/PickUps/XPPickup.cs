using UnityEngine;

public class XPPickup : Pickup
{
    [SerializeField] float _xpAmount;
    public override void PickUp(Player player)
    {
        player.GetXPComponent().GainXP(_xpAmount);

        DestroyPickup();
    }
}
