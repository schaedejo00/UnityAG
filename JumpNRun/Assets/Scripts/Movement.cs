using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float maxSpeedBackward = 1;
	public float maxSpeedForward = 2;
	public float jumpForce = 470;
	public bool jumpAble = true;
	public float jumpAbleTime = 1;
	private float jumpTime = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!jumpAble) {
			jumpTime = timer (jumpTime);
		}
		Rigidbody rb = gameObject.GetComponent<Rigidbody> ();

		if (Input.GetKey (KeyCode.A)) {
			if(rb.transform.rotation.eulerAngles != new Vector3(0,180,0)){
				rb.transform.eulerAngles = new Vector3( 0,180,0);
			}
			addForceTillMaxSpeed (rb, new Vector3 (-100, 0, 0), maxSpeedBackward);
		}
		if (Input.GetKey (KeyCode.D)) {
			if(rb.transform.rotation.eulerAngles != new Vector3(0,0,0)){
				rb.transform.eulerAngles = new Vector3( 0,0,0);
			}
			addForceTillMaxSpeed (rb, new Vector3 (100, 0, 0), maxSpeedForward);
		}
		if (Input.GetKeyDown (KeyCode.W) && jumpAble) {
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
	float timer(float timeLeft){
		timeLeft -= Time.deltaTime;
			if (timeLeft < 0)
			{
				jumpAble = true;
			timeLeft = jumpAbleTime;
			}
		return timeLeft;
		}
	}