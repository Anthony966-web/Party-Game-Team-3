using UnityEngine;
using UnityEngine.InputSystem;

public class LocalPlayer : MonoBehaviour
{

    public int playerNumber;

    void Awake()
    {
        PlayerInput input = GetComponent<PlayerInput>();

        playerNumber = input.playerIndex + 1;
    }
}
