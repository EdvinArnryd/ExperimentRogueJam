using UnityEngine;

public class SpeedPotionPickup : Pickup
{
    [SerializeField, Range(1,5)] private int _speedBoost = 5;
    [SerializeField, Range(1,3)] private float _duration = 3f;

    public override void PickUp(Player player)
    {
        player.GetComponent<PlayerController>().MovementSpeedBoost(_speedBoost, _duration);

        DestroyPickup();
    }
}
