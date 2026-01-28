using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System.Linq;



public class HightTracker : MonoBehaviour
{
    [Header("players on slider")]
    // slider on side for player
    public Slider[] playerSliderHight;

    [Header("crowns")]
// crowns for players
    public Slider winnerCrown;
    public Slider loserCrown;

    void Update()
    {
        //start and finish hight things
        float start = GameObject.Find("start").transform.position.y;
        float finish = GameObject.Find("finish").transform.position.y;

        // find all players in scene
        PlayerInput[] players = GameObject.FindObjectsByType<PlayerInput>(FindObjectsSortMode.None);
        float[] heights = new float[players.Length];

        for (int i = 0; i < players.Length; i++)
        {
            // find hight for p1
            heights[i] = Mathf.InverseLerp(start, finish, players[i].transform.position.y);
            // sets slider to hight in level for p1
            playerSliderHight[i].value = heights[i];
        }

        // Create an array with each of the heights, then sort it biggest to smallest
        float[] orderedHeights = heights.OrderBy(h => -h).ToArray();

        // sets crowns to players hight on slider
        if (orderedHeights.Length > 0)
        {
            winnerCrown.value = orderedHeights[0]; // 0 is first in array.
            loserCrown.value = orderedHeights[^1]; // ^1 is last in array.
        }
    }

    public void Join(PlayerInput player)
    {
        playerSliderHight[player.playerIndex].gameObject.SetActive(true);
    }
}
