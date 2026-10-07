using UnityEngine;

public class CoinPickup : Pickup
{
    [SerializeField, Range(1,5)] private int _coinAmount;
    
    public override void PickUp(Player player)
    {
        player.AddCoin(_coinAmount);

        DestroyPickup();
    }
}
