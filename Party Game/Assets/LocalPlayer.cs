using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class LocalPlayer : MonoBehaviour
{

    public int playerNumber;

    void Awake()
    {
        PlayerInput input = GetComponent<PlayerInput>();

        Debug.Log("Player Input Index: " + input.transform);

        playerNumber = input.playerIndex + 1;

        gameObject.name = "LocalPlayer" + playerNumber;
    }

    void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        List<GameObject> validTargets = new List<GameObject>();
        foreach (GameObject player in players)
        {
            if (player.transform.Find("Camera").Find("Canvas (1)").GetComponent<PlayerCanvasUI>().IsPaused == true)
            {
                validTargets.Add(player);
            }
        }
        if (validTargets.Count > 0)
        {
            Time.timeScale = 0; // paused
        }
        else
        {
            Time.timeScale = 1; // not paused
        }
    }
}
