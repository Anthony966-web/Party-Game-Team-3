using UnityEngine;
using TMPro;

public class PlayerCanvasUI : MonoBehaviour
{
    public TMP_Text playerNumber;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LocalPlayer player = GetComponentInParent<LocalPlayer>();

        if (player != null)
        {
            playerNumber.text = "Player " + (player.playerNumber).ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
