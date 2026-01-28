using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public Items items;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision == null) return;

        if (collision.gameObject.CompareTag("Player"))
        {

            Destroy(gameObject);
        }
    }
}