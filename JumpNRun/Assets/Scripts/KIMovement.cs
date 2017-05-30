using UnityEngine;
using System.Collections;

public class KIMovement : MonoBehaviour {

    public float maxSpeed = float.PositiveInfinity;
	public float maxJump = float.PositiveInfinity;

    int speed = 25;
	bool FacingForward = true;
	int changeDirection;


    void Update ()
	{
		doRotation ();

		if (FacingForward) 
		{
			front (maxSpeed);

		} else {
			back (maxSpeed);
		}
			

	
	}
		

	void OnTriggerEnter (Collider col)
	{

			jump (maxJump);

	}



	void OnCollisionEnter (Collision col) {
		if (col.collider.tag  == ("OutMap")) {
			Destroy (gameObject);
		}
	}

		


	void doRotation()
	{
		changeDirection = Random.Range (0, 251);

		if (changeDirection > 248) {
			ChangeDirection ();
		}
	}

	void Start () 
	{

	}

	void ChangeDirection()
	{
		if (FacingForward) {
			FacingForward = false;
		} else {
			FacingForward = true;
		}
		
	}
		

    void addForceTillMaxSpeed(Rigidbody rb, Vector3 force, float maxSpeed)
    {
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(force);
        }
        else
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

	void front(float maxSpeed)
	{
		Rigidbody rb = GetComponent<Rigidbody> ();
		addForceTillMaxSpeed(rb, new Vector3(speed * 1, 0, 0), maxSpeed);
	}

	void back(float maxSpeed)
	{
		Rigidbody rb = GetComponent<Rigidbody> ();
		addForceTillMaxSpeed(rb, new Vector3(speed * -1, 0, 0), maxSpeed);
	}

	void jump(float maxJump)
	{
		Rigidbody rb = GetComponent<Rigidbody> ();
		addForceTillMaxSpeed (rb, new Vector3 (0, 1500, 0), maxJump);
	}
}