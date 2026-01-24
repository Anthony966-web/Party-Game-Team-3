using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using System.Linq;


public class HightTracker : MonoBehaviour
{
    [Header("players on slider")]
    // slider on side for player
    public Slider player1SliderHight;
    public Slider player2SliderHight;
    public Slider player3SliderHight;
    public Slider player4SliderHight;

    [Header("crowns")]
// crowns for players
    public Slider player1Crown;
    public Slider player2Crown;
    public Slider player3Crown;
    public Slider player4Crown;

    void Update()
    {
        // players/ finds y value of players
        float p1 = GameObject.Find("player1").transform.position.y;
        float p2 = GameObject.Find("player2").transform.position.y;
        float p3 = GameObject.Find("player3").transform.position.y;
        float p4 = GameObject.Find("player4").transform.position.y;
        

        //start and finish hight things
        float start = GameObject.Find("start").transform.position.y;
        float finish = GameObject.Find("finish").transform.position.y;

        // find hight for p1
        float ph1 = Mathf.InverseLerp(start, finish, p1);
        // sets slider to hight in level for p1
        player1SliderHight.value = ph1;

        // find hight for p2
        float ph2 = Mathf.InverseLerp(start, finish, p2);
        // sets slider to hight in level for p2
        player2SliderHight.value = ph2;

        // find hight for p3
        float ph3 = Mathf.InverseLerp(start, finish, p3);
        // sets slider to hight in level for p3
        player3SliderHight.value = ph3;

        //find hight for p4
        float ph4 = Mathf.InverseLerp(start, finish, p4);
        // sets slider to hight in level for p4
        player4SliderHight.value = ph4;

        // sets crowns to players hight on slider
        player1Crown.value = ph1;
        player2Crown.value = ph2;
        player3Crown.value = ph3;
        player4Crown.value = ph4;

        // checks what player is currently winning
        if (p1 > p2 && p1 > p3 && p1 > p4)
        {
            GameObject.Find("player 1 crown").SetActive(true);
        }
        else
        {
            GameObject.Find("player 1 crown").SetActive(false);
        }

        if (p2 > p1 && p2 > p3 && p2 > p4)
        {
            GameObject.Find("player 2 crown").SetActive(true);
        }
        else
        {
            GameObject.Find("player 2 crown").SetActive(false);
        }

        if (p3 > p1 && p3 > p2 && p3 > p4)
        {
            GameObject.Find("player 3 crown").SetActive(true);
        }
        else
        {
            GameObject.Find("player 3 crown").SetActive(false);
        }

        if (p4 > p1 && p4 > p2 && p4 > p3)
        {
            GameObject.Find("player 4 crown").SetActive(true);
        }
        else
        {
            GameObject.Find("player 4 crown").SetActive(false);
        }
    }
}
