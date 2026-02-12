using UnityEngine;

public class ItemObject : MonoBehaviour
{
    [Tooltip("Assigns the item to the player's inventory upon collision.")]
    public Items item;
    public Items JumpBoost;
    public Items SpeedBoost;
    public Items Bounce;
    public Items Stun;
    public Items Teleport;

    void Awake()
    {
        if (item != null)
        {
            GetComponent<SpriteRenderer>().sprite = item.RandomSprite;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision == null) return;

        if (collision.gameObject.CompareTag("Player") && collision.transform.GetComponent<PlayerMovement>().item == null) // Check If The Player Is Already Holding An Item
        {
            int randomizedItem = Random.Range(1, 5);

            if (randomizedItem == 1)
            {
                collision.gameObject.GetComponent<PlayerMovement>().item = JumpBoost;
            }
            else if (randomizedItem == 2)
            {
                collision.gameObject.GetComponent<PlayerMovement>().item = SpeedBoost;
            }
            else if (randomizedItem == 3)
            {
                collision.gameObject.GetComponent<PlayerMovement>().item = Bounce;
            }
            else if (randomizedItem == 4)
            {
                collision.gameObject.GetComponent<PlayerMovement>().item = Stun;
            }
            else if (randomizedItem == 5)
            {
                collision.gameObject.GetComponent<PlayerMovement>().item = Teleport;
            }
            // Add Item To Player Inventory
            Destroy(gameObject);
        }
    }
}