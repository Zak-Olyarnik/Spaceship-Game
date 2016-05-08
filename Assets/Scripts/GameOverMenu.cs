using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// controls game over menu navigation
public class GameOverMenu : MonoBehaviour
{
    public Canvas gameOverMenu;     // game over menu UI
    public Button restartButton;    // restart button UI
    public Button menuButton;       // menu button UI
    public Text lastScoreText;      // last score text UI
    public Text highScoreText;      // high score text UI
    private int lastScore;          // last score
    private int highScore;          // high score


    void Start()
    {
        // loads and displays scores
        lastScore = PlayerPrefs.GetInt("LastScore");
        highScore = PlayerPrefs.GetInt("HighScore");
        lastScoreText.text = "Score: " + lastScore;
        highScoreText.text = "High Score: " + highScore;
    }

    // loads main menu
    public void MenuClick()
    {
        Application.LoadLevel("MainMenu");
    }
    
    // loads main level
    public void RestartClick()
    {
        Application.LoadLevel("MainLevel");
    }


}
