using UnityEngine;
using System.Collections;

// destroys objects that collide with the hazards
public class HazardDeath : MonoBehaviour
{
    // detects collisions
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Background" || other.tag == "Score")  // don't destroy Background object
        {
            return;
        }
        //Instantiate(explosion, transform.position, transform.rotation);   // currently missing this art
        if (other.tag == "Player")  // set game over flag if player is destroyed
        {
        //Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            GameController.getInstance().gameOver = true;
        }
        Destroy(other.gameObject);  // destroys whatever collided with the hazard
        //Destroy(gameObject);      // destroys the hazard also
    }
}
