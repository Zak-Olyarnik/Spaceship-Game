using UnityEngine;
using System.Collections;

// controls movement of all non-player objects
public class Mover : MonoBehaviour
{
    public Rigidbody2D rb;      // moving object
    public float speed;         // speed value multiplier


    void Start()
    {
       Vector2 movement = new Vector2(0.0f, 1.0f);  // controls direction of movement
       rb.velocity = movement * speed;              // adjusts speed
       //rb.velocity = transform.up * speed;
    }
}
