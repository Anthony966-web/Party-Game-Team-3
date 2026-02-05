using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Menu time!!!
            SceneManager.LoadScene(SceneManager.GetActiveScene(),"title screne");
        }
    }
}
