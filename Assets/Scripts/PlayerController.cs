using UnityEngine;
using System.Collections;

// controls all player ship functionality
public class PlayerController : MonoBehaviour
{
    public float speed;                         // speed value multiplier (originally 4)
    public float xMin, xMax;                    // values for edges of screen
    public float tilt;                          // angle for rotation
    public Rigidbody2D rb;                      // physics component
    public GameObject shot;                     // the shot object
    public Transform shotSpawn;                 // and its transform
    public float fireRate;                      // delay between firing shots
    public static PlayerController instance;    // instance of the player
    
    private float nextFire;     // holds a timestamp for when the next shot can be fired

   
    void Start()
    {
        instance = this;    // sets instance
    }

    void FixedUpdate()  // used for physics
    {
        float moveHorizontal = Input.GetAxis("Horizontal");     // gets user movement input (arrow keys)
        //float moveHorizontal = Input.acceleration.x;          // gets user movement input (touch)
        Vector2 movement = new Vector2(moveHorizontal, 0.0f);   // converts to vector2
        rb.velocity = movement * speed;                         // applies to rigidbody's velocity

        rb.position = new Vector2(Mathf.Clamp(rb.position.x, xMin, xMax), rb.position.y);   // stops ship from leaving screen
        rb.MoveRotation(tilt * moveHorizontal);                                             // rotates ship with movement
    }

    void Update()   // called every frame
    {
        Vector3 shotOffsetPos = new Vector3(shotSpawn.position.x, shotSpawn.position.y + 1, shotSpawn.position.z);  // sets shot spawn position slightly in front of ship
        Quaternion shotOffsetRot = new Quaternion(90, 0, 0, 0); // sets shot spawn orientation
        
        if (Input.GetButton("Fire1") && Time.time > nextFire)   // checks for fire button and if time delay has passed
        {
            nextFire = Time.time + fireRate;                    // increases timestamp
            Instantiate(shot, shotOffsetPos, shotOffsetRot);    // actually does the spawning
        }
    }

    // gets current instance of the player
    public static PlayerController getInstance()
    {
        return instance;
    }

}
