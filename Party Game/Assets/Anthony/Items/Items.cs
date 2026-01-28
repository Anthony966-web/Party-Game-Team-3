using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Items", menuName = "Scriptable Objects/Items")]
public class Items : ScriptableObject
{
    public Sprite Icon;
    public string ItemName;
    public GameObject Item;
    [TextArea(4, 4)] public string description;

    public void UseItem(Items item) // Get What player Sent This So You Can Remove It From Players Inventory And To Give Effects And Get The A Random Player That Is Not The Same Person As The Player Sending It
    {
        Debug.Log($"Using item: {item.ItemName}");

        switch(item.ItemName)
        {
            case "Stun":
                // Logic To Stun The Player Above You
                Stun();
                Debug.Log("Stun Function Called!");
                break;
            case "Speed Boost":
                // Logic To Give the Player A Speed Boost
                Debug.Log("Speed Boost Function Called!");
                break;
            case "Jump Boost":
                // Logic To Give The Player A Jump Boost
                Debug.Log("Jump Boost Function Called!");
                break;
            case "Teleport":
                // Logic To Teleport The Player To A Random Player Location
                Debug.Log("Teleport Function Called!");
                break;
            default:
                Debug.Log("Item has no use effect.");
                break;
        }
    }

    public void Stun()
    {
        Debug.Log("Item used to stun an enemy!");
    }
}