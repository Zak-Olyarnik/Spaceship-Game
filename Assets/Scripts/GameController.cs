using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// controls gameplay with hazard spawning, 
public class GameController : MonoBehaviour
{
    public float spawnTime;                     // time delay between hazard spawns
    public GameObject[] hazard;                 // list of all available hazards
    public Text scoreText;                      // displays score
    public int hazardScore;                     // score per hazard cleared
    public bool gameOver = false;               // game over flag
    private int score = 0;                      // starting score
    private int highScore;                      // stored high score
    public static GameController instance;      // instance of the gameController


    void Start()
    {
        instance = this;    // sets instance
        //instance = init; 
        //IEnumerator e = StartSpawning();
        StartCoroutine(SpawnHazard());      // starts the spawning of hazards
        //StartCoroutine(e);
        //StopCoroutine(e);
    }

    void Update()
    {
        if (gameOver)
        {
            // compares current score to high score and updates if necessary
            PlayerPrefs.SetInt("LastScore", score);
            highScore = PlayerPrefs.GetInt("HighScore");
            if (score > highScore)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
            Application.LoadLevel("GameOverMenu");       // loads game over menu
        }
    }

    // gets current instance of the gameController
    public static GameController getInstance()
    {
        return instance;
    }
    
    // Hazard spawning coroutine
    IEnumerator SpawnHazard()
    {
        Vector3 spawnPosition = new Vector3(0, 7, 0);       // sets hazard spawn point just off screen
        Quaternion spawnRotation = Quaternion.identity;     // sets hazard spawn orientation

        while (! gameOver)
        {
            GameObject currentHazard = hazard[Random.Range(0, hazard.Length)];  // randomly picks a hazard from the list
            Instantiate(currentHazard, spawnPosition, spawnRotation);           // actually does the spawning
            yield return new WaitForSeconds(spawnTime);                         // delays until next hazard spawn
        }
    }

    // updates and displays the score when a hazard is cleared
    public void UpdateScore()
    {
        score += hazardScore;
        scoreText.text = "Score: " + score;
    }

}
