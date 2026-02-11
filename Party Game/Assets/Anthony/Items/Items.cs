using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Items", menuName = "Scriptable Objects/Items")]
public class Items : ScriptableObject
{
    public Sprite Icon;
    public Sprite RandomSprite;
    public string ItemName;

    public GameObject SoundGameObject;

    public AudioClip StunSound;

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

        // Instantiate the sound GameObject at the player's position
        GameObject instance = Instantiate(SoundGameObject, RandomPlayer.position, Quaternion.identity);

        AudioSource source = instance.GetComponent<AudioSource>();
        if (source != null)
        {
            if (StunSound != null)
            {
                // Option A: play the clip and destroy the object after the clip finishes
                source.PlayOneShot(StunSound);
                Destroy(instance, StunSound.length + 0.1f);
            }
            else
            {
                // No clip assigned: try to play any assigned clip on the AudioSource, else destroy after default
                if (source.clip != null)
                {
                    source.Play();
                    Destroy(instance, source.clip.length + 0.1f);
                }
                else
                {
                    Debug.LogWarning("No StunSound and AudioSource.clip is null. Destroying instance after 2 seconds.");
                    Destroy(instance, 2f);
                }
            }
        }
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