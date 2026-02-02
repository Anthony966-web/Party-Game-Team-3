using UnityEngine;
using UnityEngine.InputSystem;

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
}
