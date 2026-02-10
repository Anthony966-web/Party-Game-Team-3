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

        for (int i = 0; i < players.Length; i++)
        {
            // sets slider to hight in level for each player
            playerSliderHight[i].value = Mathf.InverseLerp(start, finish, players[i].transform.position.y);
        }

        // Create an array with each of the heights, then sort it biggest to smallest
        var orderedHeights = playerSliderHight.OrderBy(h => -h.value).ToArray();

        // sets crowns to players hight on slider
        if (orderedHeights.Length > 0)
        {
            winnerCrown.value = orderedHeights[0].value; // 0 is first in array.
            loserCrown.value = orderedHeights[^1].value; // ^1 is last in array.
        }
    }

    public void Join(PlayerInput player)
    {
        playerSliderHight[player.playerIndex].gameObject.SetActive(true);
    }
}
