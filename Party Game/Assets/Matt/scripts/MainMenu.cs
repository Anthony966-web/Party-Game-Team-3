using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject HelpPanel;

    public void Playgame()
    {
        SceneManager.LoadScene("Level 1");
        HelpPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
