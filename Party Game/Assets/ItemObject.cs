using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [Tooltip("Assigns the item to the player's inventory upon collision.")]
    public Items item;

    void Awake()
    {
        if (item != null)
        {
            GetComponent<SpriteRenderer>().sprite = item.Icon;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision == null) return;

        if (collision.gameObject.CompareTag("Player") && collision.transform.GetComponent<PlayerMovement>().item == null) // Check If The Player Is Already Holding An Item
        {
            // Add Item To Player Inventory

            collision.gameObject.GetComponent<PlayerMovement>().item = item;
            Destroy(gameObject);
        }
    }
}