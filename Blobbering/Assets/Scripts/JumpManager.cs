using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpManager : MonoBehaviour {
	public KeyCode jump;
	public float jumpspeed;
	public float gravity;
	public float cooldown;

	private bool isAir = false;
	private float timer;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= timer && isAir == true) {
			rb.AddForce (new Vector3 (0, gravity * -jumpspeed, 0));
			timer = Time.time + cooldown;
			print ("is push down");
		}
		
	}
	void OnCollisionStay (Collision col){
		if (col.gameObject.tag == "Terrain") {
			isAir = false;
			if (Input.GetKeyDown (jump)) {
				rb.AddForce (new Vector3 (0, jumpspeed, 0));
				isAir = true;
				timer = Time.time + cooldown;
			}

		}
	}
	void OnCollisionEnter (Collision col){
		if (col.gameObject.tag == "Terrain") {
			print ("Kollision");
			isAir = false;
		}
	}
	void OnCollisionExit (Collision col){
		if (col.gameObject.tag == "Terrain") {
			isAir = true;
			print ("isAir is true");
			timer = Time.time + cooldown;
		}
	}
}
