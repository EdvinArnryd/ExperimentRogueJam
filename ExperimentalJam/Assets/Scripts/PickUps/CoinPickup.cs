using UnityEngine;

public class CoinPickup : Pickup
{
    [SerializeField, Range(1,5)] private int _coinAmount;
    
    public override void PickUp()
    {
        GameManager.Instance.Player.AddCoin(_coinAmount);

        DestroyPickup();
    }
}
