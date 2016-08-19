using UnityEngine;
using System.Collections;

public class explosionTrigger : MonoBehaviour
{

    Rigidbody rb;
    public bool collided, removing;
    float t;
    public static float removeTimeLimit = 3f, backUpRemoveTimeLimit = 3 * removeTimeLimit; // in seconds
    public static float minImpulse = 0.0f;
	public static bool alive = true;

    // Use this for initialization
    void Start()
    {
        t = 0;
        collided = false;
        removing = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        // if the collision has happened
        if (collided)
        {
            // start the timer
            t += Time.deltaTime;

            // if this piece has stopped moving or it has been to long
            if (rb.velocity.magnitude == 0 || t > backUpRemoveTimeLimit)
            {
                // if this piece has been sitting still for long enough
                if (t > removeTimeLimit)
                {
                    // remove this piece
                    gameObject.SetActive(false);
					alive = false;
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name.Equals("Wall") && !collided && collision.impulse.magnitude >= minImpulse)
        {
            collided = true;
            rb.useGravity = true;
            // create point of explosion between knees
            GameObject torso = GameObject.Find("Torso"), leg = GameObject.Find("Right Leg");
            Vector3 explosionPoint = new Vector3(torso.transform.position.x, leg.transform.position.y, torso.transform.position.z);
            rb.AddExplosionForce(1000f, explosionPoint, 10f);
        }
    }
}