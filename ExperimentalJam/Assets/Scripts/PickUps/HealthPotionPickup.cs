using UnityEngine;

public class HealthPotionPickup : Pickup
{
    [SerializeField, Range(1,5)] private int _healAmount;
    
    public override void PickUp(Player player)
    {
        Health playerHealth = player.GetComponent<Health>();

        if(playerHealth.GetMaxHealth() == playerHealth.GetHealth())
        {
            return;
        }

        playerHealth.GainHealth(_healAmount);

        DestroyPickup();
    }
}
