using UnityEngine;

public class HealthPotionPickup : Pickup
{
    [SerializeField, Range(1,5)] private int _healAmount;
    
    public override void PickUp()
    {
        Health playerHealth = GameManager.Instance.Player.GetComponent<Health>();

        if(playerHealth.GetMaxHealth() == playerHealth.GetHealth())
        {
            return;
        }

        GameManager.Instance.Player.GetComponent<Health>().GainHealth(_healAmount);

        DestroyPickup();
    }
}
