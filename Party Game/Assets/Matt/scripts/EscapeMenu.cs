using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class EscapeMenu : MonoBehaviour
{
    public GameObject escapemenu;
    public GameObject escapemenubackground;
    public GameObject settingsmenu;
    public GameObject resume;

    public bool isPaused;

    public void MainMenu()
    {
        Time.timeScale = 1;
        escapemenu.SetActive(false);
        escapemenubackground.SetActive(false);
        IsEscaped = false;
        SceneManager.LoadScene("Title_Screne");
    }
    public void Resume()
    {
        escapemenu.SetActive(false);
        escapemenubackground.SetActive(false);
        IsEscaped = false;
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // has escape menu open
    private bool IsEscaped = false;
    // is selected in escape menu not using mouse
    private bool IsSelected = false;

    public void Interact(InputAction.CallbackContext ctx)
    {
        if (isPaused == false)
        {
            isPaused = true;
            transform.GetComponent<PlayerCanvasUI>().IsPaused = true;
            escapemenu.SetActive(true);
        }
        else if (isPaused == true)
        {
            isPaused = false;
            transform.GetComponent<PlayerCanvasUI>().IsPaused = false;
            escapemenu.SetActive(false);
        }
    }
}

