﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public KeyCode forward;
	public KeyCode left;
	public KeyCode back;
	public KeyCode right;
	public KeyCode dashKey;
	public KeyCode brakekey;
	public KeyCode fly;
	public KeyCode reset;
	public float maxSpeed = 5;
	public float defaultSpeed = 400f;
	public float rotationSpeed = 50;
	public float dashMax = 150;
	public float dashTime = 10;
	public float dashSpeed = 5;
	public float brake = 0.05f;
	public float brakeStop = 0.2f;
	public float RotationSpeedy = 5;
	//public AudioSource motorSoundSource;
	//public AudioClip engineDriving;
	//public AudioClip engineIdle;

	private bool activeSpecialKeys = false;
	private float speed = 2.5f;
	private LiveManager liveManager;
	private bool isAlive;
	private Vector3 startPosition;
	private float gravityon = 1;
	private Rigidbody rb;
	private float rotation;
	private float dashon = 0;
	private float dashcount = 0;
	private float yrot;

	void Start () {
		Cursor.visible = false;
		isAlive = true;
		activeSpecialKeys = false;
		speed = defaultSpeed;
		rb = GetComponent<Rigidbody> ();
		startPosition = transform.position;
		liveManager = GetComponent<LiveManager> ();
		liveManager.onDeath += die;
	}

	void die(){
		isAlive = false;
	}
    void die(string killer)
    {
        isAlive = false;
        Debug.Log(killer);
    }

    void Update () {
		yrot = (Input.GetAxis ("Mouse X") * RotationSpeedy * Time.deltaTime);
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y +  yrot, transform.eulerAngles.z);
		//Physics.gravity = new Vector3(0, -20.0F, 0);
		if (isAlive) {
			movementControls ();
			if (Input.GetKey (KeyCode.Alpha2) && Input.GetKey (KeyCode.Alpha3) && Input.GetKeyDown (KeyCode.Alpha7)) {
				activeSpecialKeys = !activeSpecialKeys;
				Debug.Log (activeSpecialKeys);
			}
			if (Input.GetKey (reset)) {
				resetPlayer ();
			}
			//if (rb.velocity.magnitude > 0) {
				//motorSoundSource.clip = engineDriving;
			//} else {
				//motorSoundSource.clip = engineIdle;
			//}
			//if (!motorSoundSource.isPlaying) {
				//motorSoundSource.Play () ;
			//}
			specialControls ();
			//if (isAir == true && Time.time > timer) {
				//rb.AddForce (new Vector3 (0, gravity * -jumpspeed, 0));
			//	print ("truejump is true");
			//	timer = Time.time + cooldown;
				
			}
		}


	private void dash(){
		if (Input.GetKey (dashKey) && dashcount < dashMax) {
			dashcount = dashcount + 1;
		}
		if (Input.GetKeyUp (dashKey)) {
			dashon = dashTime;
			speed = 1000 + dashSpeed * dashcount;
			rotationSpeed = 50 + 0.1f * dashSpeed * dashcount;
			Debug.Log (speed);
		}
	}

	private void specialControls(){
		if (activeSpecialKeys) {
			if (Input.GetKeyDown (fly)) {
				if (gravityon == 1) {
					gravityon = 0;
					rb.useGravity = false;
					rb.velocity = Vector3.zero;
				} else if (gravityon == 0) {
					gravityon = 1;
					rb.useGravity = true;
				}
			}	

			if (Input.GetKey (brakekey)) {
				if (rb.velocity.magnitude > brakeStop) {
					rb.velocity = rb.velocity * (1 - brake);
				} else {
					rb.velocity = Vector3.zero;
				}
			}
			dash ();
		}
		if (dashon <= 0) {
			limitVelocity ();
			rotationSpeed = 50;
			speed = defaultSpeed;
		} else {
			dashon--;
			dashcount = 0;
		}
	}

	private void limitVelocity(){
		if (rb.velocity.magnitude >= maxSpeed) {
			Vector3 highSpeed = rb.velocity.normalized * maxSpeed;
			highSpeed.y = rb.velocity.y;
			rb.velocity = highSpeed;
		}
	}

	private void resetPlayer(){
		transform.position = startPosition;
		transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 0));
		speed = defaultSpeed;
	}

	private void movementControls(){
		if (Input.GetKey (forward)) {
			rb.AddForce (transform.forward.normalized * speed);
		}
		if (Input.GetKey (back)) {
			rb.AddForce (transform.forward.normalized * -speed);
		}
		if (Input.GetKey (left)) {
			rb.AddForce (transform.right.normalized * -speed);
		}
		if (Input.GetKey (right)) {
			rb.AddForce (transform.right.normalized * speed);
		}
        if (Input.GetKey(KeyCode.Comma))
        {
            liveManager.Health = 0;
        }
    }
}