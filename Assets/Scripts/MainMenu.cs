using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// controls main menu navigation
public class MainMenu : MonoBehaviour
{
    public Canvas quitMenu;     // quit menu UI
    public Button startButton;  // start button UI
    public Button quitButton;   // quit button UI


    void Start()
    {
        quitMenu.enabled = false;   // quit menu starts disabled
    }

    // displays quit confirmation
    public void QuitClick()
    {
        quitMenu.enabled = true;
        startButton.enabled = false;
        quitButton.enabled = false;
    }
    
    // resets main menu
    public void NoClick()
    {
        quitMenu.enabled = false;
        startButton.enabled = true;
        quitButton.enabled = true;
    }

    // loads main level
    public void StartClick()
    {
        Application.LoadLevel("MainLevel");   
    }

    // exits
    public void YesClick()
    {
        Application.Quit();
    }

}
