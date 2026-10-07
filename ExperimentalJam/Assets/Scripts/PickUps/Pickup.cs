using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] public AudioClip _audio;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if(player != null)
        {
            PickUp(player);
        }
    }

    public abstract void PickUp(Player player);

    protected void DestroyPickup()
    {
        Destroy(gameObject);
    }
}
