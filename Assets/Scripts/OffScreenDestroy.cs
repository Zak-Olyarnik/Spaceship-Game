using UnityEngine;
using System.Collections;

// automatically destroys anything that leaves the screen
public class OffScreenDestroy : MonoBehaviour
{
    // when objects are out of collision range
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Score")
        {
            GameController.getInstance().UpdateScore();     // calls the update score function in GameController script once the ship passes a hazard
        }
        
        Destroy(other.gameObject, 1.0f);    // destroys the hazard once it moves offscreen
    }
}
