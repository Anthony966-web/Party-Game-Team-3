using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LadderMovement : MonoBehaviour
{
    private float speed = 8f;
    private bool isLadder;

    private List<(Rigidbody2D, PlayerInput)> players = new();

    private void FixedUpdate()
    {
        foreach (var (r, input) in players)
        {
            float vertical = input.actions["Move"].ReadValue<Vector2>().y;

            if (vertical > 0)
            {
                r.gravityScale = 0f;
                r.linearVelocity = new Vector2(r.linearVelocity.x, vertical * speed);
            }
            else
            {
                r.gravityScale = 4f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isLadder = true;

            players.Add((collision.GetComponent<Rigidbody2D>(), collision.GetComponent<PlayerInput>()));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       if (collision.CompareTag("Player"))
        {
            isLadder = false;

            players.Remove((collision.GetComponent<Rigidbody2D>(), collision.GetComponent<PlayerInput>()));
        }
    }
}
