using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SplitScreen : MonoBehaviour
{
    public Image divider;
    public Sprite twoPlayers;
    public Sprite fourPlayers;

    // Update is called once per frame
    void Update()
    {
        int playerCount = FindObjectsByType<PlayerInput>(FindObjectsSortMode.None).Length;

        if(playerCount < 2) // no divider
        {
            divider.enabled = false;
        }
        else if (playerCount < 3) // vertical divider
        {
            divider.sprite = twoPlayers;
            divider.enabled = true;
        }
        else // four player divider
        {
            divider.sprite = fourPlayers;
            divider.enabled = true;
        }
    }
}
