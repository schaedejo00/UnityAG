using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float maxSpeedBackward = 1;
	public float maxSpeedForward = 2;
	public float jumpForce = 1000;
	public bool jumpAble = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer (2);
		Rigidbody rb = gameObject.GetComponent<Rigidbody> ();
		if (Input.GetKey (KeyCode.A)) {
			addForceTillMaxSpeed (rb, new Vector3 (-100, 0, 0), maxSpeedBackward);
		}
		if (Input.GetKey (KeyCode.D)) {
			addForceTillMaxSpeed (rb, new Vector3 (100, 0, 0), maxSpeedForward);
		}
		if (Input.GetKeyDown (KeyCode.Space) && jumpAble) {
			rb.AddForce (new Vector3 (0, jumpForce, 0));
			jumpAble = false;
		}
	}


	void addForceTillMaxSpeed(Rigidbody rb, Vector3 force, float maxSpeed){
		
		if (rb.velocity.magnitude < maxSpeed) {
			rb.AddForce (force);
		} else {
			rb.velocity = rb.velocity.normalized * maxSpeed;
		}
	}
		void timer(float timeLeft){
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0)
			{
				jumpAble = true;
			}
		}
	}