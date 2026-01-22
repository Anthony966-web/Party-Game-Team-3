using UnityEngine;
using UnityEngine.SceneManagement;
public class Credits : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("title screne");
        }
    }
}
