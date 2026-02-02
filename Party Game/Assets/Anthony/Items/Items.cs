using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Items", menuName = "Scriptable Objects/Items")]
public class Items : ScriptableObject
{
    public Sprite Icon;
    public string ItemName;
    [TextArea(4, 4)] public string description;

    public void UseItem(Items item, Transform FromPlayer, Transform RandomPlayer) // Get What player Sent This So You Can Remove It From Players Inventory And To Give Effects And Get The A Random Player That Is Not The Same Person As The Player Sending It
    {
        Debug.Log($"Using item: {item.ItemName}");
        Debug.Log(FromPlayer.name);
        Debug.Log(RandomPlayer.name);

        switch(item.ItemName)
        {
            case "Stun":
                // Logic To Stun The Player Above You
                Stun(RandomPlayer);
                Debug.Log("Stun Function Called!");
                break;
            case "Speed Boost":
                // Logic To Give the Player A Speed Boost
                SpeedBoost(FromPlayer);
                Debug.Log("Speed Boost Function Called!");
                break;
            case "Jump Boost":
                // Logic To Give The Player A Jump Boost
                JumpBoost(FromPlayer);
                Debug.Log("Jump Boost Function Called!");
                break;
            case "Teleport":
                // Logic To Teleport The Player To A Random Player Location
                Teleport(FromPlayer, RandomPlayer);
                Debug.Log("Teleport Function Called!");
                break;
            case "Bounce":
                // Logic To Spawn A Bounce To Bounce Players
                Bounce(FromPlayer);
                Debug.Log("Teleport Function Called!");
                break;
            default:
                Debug.Log("Item has no use effect.");
                break;
        }
    }

    public void Stun(Transform RandomPlayer)
    {
        RandomPlayer.GetComponent<PlayerMovement>().IsStunned = true;
        Debug.Log("Item used to stun an enemy!");
    }

    public void SpeedBoost(Transform FromPlayer)
    {
        FromPlayer.GetComponent<PlayerMovement>().SpeedBoost = true;
        Debug.Log("Item used for player speed boost!");
    }

    public void JumpBoost(Transform FromPlayer)
    {
        FromPlayer.GetComponent<PlayerMovement>().JumpBoost = true;
        Debug.Log("Item used for player jump boost!");
    }

    public void Teleport(Transform FromPlayer, Transform RandomPlayer)
    {
        FromPlayer.transform.position = RandomPlayer.transform.position + new Vector3(2, 0, 0); // Teleport Next To The Random Player
        Debug.Log("Item used to teleport to: " + RandomPlayer.transform.name);
    }

    public void Bounce(Transform FromPlayer)
    {
        FromPlayer.GetComponent<PlayerMovement>().SpawnBounce(FromPlayer);
        Debug.Log("Item used to Bounce");
    }
}