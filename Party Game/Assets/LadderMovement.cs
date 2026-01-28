using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private float vertical;
    private float speed = 8f;
    private bool isLadder;
    private bool isClimbing;

    private List<Rigidbody2D> rb = new();


    private void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
        else
        {
            foreach (var r in rb)
            {
             r.gravityScale = 4f;

            }
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            foreach (var r in rb)
            {
                r.gravityScale = 0f;
                r.linearVelocity = new Vector2(r.linearVelocity.x, vertical * speed);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isLadder = true;
            rb.Add(collision.GetComponent<Rigidbody2D>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       if (collision.CompareTag("Player"))
        {
            isLadder = false;
            isClimbing = false;
            rb.Remove(collision.GetComponent<Rigidbody2D>());
        }
    }


}
