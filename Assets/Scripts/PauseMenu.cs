using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// controls pause menu navigation
public class PauseMenu : MonoBehaviour
{
    public Canvas pauseMenu;        // pause menu UI
    public Button pauseButton;      // pause button UI


    void Start()
    {
        pauseMenu.enabled = false;  // pause menu starts disabled
    }

    // displays pause menu
    public void PauseClick()
    {
        pauseMenu.enabled = true;
        pauseButton.enabled = false;
        Time.timeScale = 0;     // freezes time
    }
    
    // returns to game
    public void ResumeClick()
    {
        pauseMenu.enabled = false;
        pauseButton.enabled = true;
        Time.timeScale = 1;     // restarts time
    }

    // loads main menu
    public void MenuClick()
    {
        Time.timeScale = 1;                 // restarts time
        Application.LoadLevel("MainMenu");
    }

}
