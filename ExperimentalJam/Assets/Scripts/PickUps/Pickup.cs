using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] public AudioClip _audio;

    void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if(player != null)
        {
            PickUp();
        }
    }

    public abstract void PickUp();

    protected void DestroyPickup()
    {
        Destroy(gameObject);
    }
}
