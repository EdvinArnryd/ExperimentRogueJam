using UnityEngine;

public class LevelupPickup : Pickup
{
    public override void PickUp(Player player)
    {
        GameManager.Instance.PauseManager.LevelUp();
        GameManager.Instance.StatGenerator.UpdateCards();

        DestroyPickup();
    }
}
