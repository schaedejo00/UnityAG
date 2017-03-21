using UnityEngine;
using System.Collections;

public class BotKDIMovement : MonoBehaviour
{

    public float maxSpeed = float.PositiveInfinity;

    int speed = 25;
    int direction;
	int startdirection;



    void Update ()
	{

		delayedRotation ();

	}


	void delayedRotation()
	{

		direction = Random.Range (0, 101);

		if (direction < 75)
			;

	}

	void Start () 
	{
		Rigidbody rb = gameObject.GetComponent<Rigidbody>();
		direction = Random.Range (0, 2);

		if (direction == 1)
		{
			addForceTillMaxSpeed(rb, new Vector3(speed * 1, 0, 0), maxSpeed);
		}
		if(direction == 2)
		{
			addForceTillMaxSpeed(rb, new Vector3(speed * -1, 0, 0), maxSpeed);
		}
	}
		

	/*void randomTime()
	{
		timedetector = Random.Range (0, 4);
		if (timedetector == 1) {
			timedirection = 1;
		} else if (timedetector == 2) {
			timedirection = 2;
		} else if (timedetector == 3) {
			timedirection = 3;
		}
	} */

    void addForceTillMaxSpeed(Rigidbody rb, Vector3 force, float maxSpeed)
    {
        Debug.LogWarning(rb.velocity.magnitude);
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(force);
        }
        else
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }
}