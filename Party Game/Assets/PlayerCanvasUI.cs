using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerCanvasUI : MonoBehaviour
{
    public TMP_Text playerNumber; // if we want to display players number on their UI

    public GameObject Sprite; // reference to the sprite game object

    public Sprite[] playerSprites; // array of player sprites for different players

    public RuntimeAnimatorController[] PlayersAnimatorController;

    public bool IsPaused;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LocalPlayer player = GetComponentInParent<LocalPlayer>();

        if (player != null)
        {
            //playerNumber.text = "Player " + (player.playerNumber).ToString();

            Debug.Log("Setting up UI for Player " + player.playerNumber);

            switch (player.playerNumber)
            {
                case 1:
                    Sprite.GetComponent<SpriteRenderer>().sprite = playerSprites[0];
                    Sprite.GetComponent<Animator>().runtimeAnimatorController = PlayersAnimatorController[0];
                    break;
                case 2:
                    Sprite.GetComponent<SpriteRenderer>().sprite = playerSprites[1];
                    Sprite.GetComponent<Animator>().runtimeAnimatorController = PlayersAnimatorController[1];
                    break;
                case 3:
                    Sprite.GetComponent<SpriteRenderer>().sprite = playerSprites[2];
                    Sprite.GetComponent<Animator>().runtimeAnimatorController = PlayersAnimatorController[2];
                    break;
                case 4:
                    Sprite.GetComponent<SpriteRenderer>().sprite = playerSprites[3];
                    Sprite.GetComponent<Animator>().runtimeAnimatorController = PlayersAnimatorController[3];
                    break;
                default:
                    Debug.LogWarning("Player number out of range: " + playerNumber);
                    break;
            }
        }
    }
}
