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
    public Slider[] playerSliderHight;
    public Slider winnerCrown;
    public Slider loserCrown;

    private Transform startTransform;
    private Transform finishTransform;

    void Start()
    {
        startTransform = GameObject.Find("start").transform;
        finishTransform = GameObject.Find("finish").transform;
    }

    void Update()
    {
        float start = startTransform.position.y;
        float finish = finishTransform.position.y;

        PlayerInput[] players = GameObject
            .FindObjectsByType<PlayerInput>(FindObjectsSortMode.None)
            .OrderBy(p => p.playerIndex)
            .ToArray();

        for (int i = 0; i < players.Length && i < playerSliderHight.Length; i++)
        {
            playerSliderHight[i].value =
                Mathf.InverseLerp(start, finish, players[i].transform.position.y);
        }

        var orderedHeights = playerSliderHight
            .OrderByDescending(h => h.value)
            .ToArray();

        if (orderedHeights.Length > 0)
        {
            winnerCrown.value = orderedHeights[0].value;
            loserCrown.value = orderedHeights[^1].value;
        }
    }

    public void Join(PlayerInput player)
    {
        playerSliderHight[player.playerIndex].gameObject.SetActive(true);
    }
}