using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkJumpManager : NetworkBehaviour {
	public KeyCode jump;
	public float jumpspeed;
	public float gravity;
	public float cooldown;
	public float jumptimeadd;

	private bool isAir = false;
	private float timer;
	private float jupmptimer = 0f;
	private float jumptime;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer)
		{
			return;
		}
		if (Time.time >= timer && isAir == true) {
			rb.AddForce (new Vector3 (0, gravity * -jumpspeed * jumptime, 0));
			jumptime = jumptime + jumptimeadd;
			timer = Time.time + cooldown;
			//print ("is push down");
		}
	}
	void OnCollisionStay (Collision col){
		if (col.gameObject.tag == "Terrain") {
			isAir = false;
			jumptime = 0;
			if (Input.GetKeyDown (jump)) {
				if (jupmptimer < Time.time) {
					print (Time.time);
					rb.AddForce (new Vector3 (0, jumpspeed, 0));
					isAir = true;
					timer = Time.time + cooldown;
					jupmptimer = Time.time + 0.1f;
				}
			}
		}
	}
	void OnCollisionEnter (Collision col){
		if (col.gameObject.tag == "Terrain") {
			//print ("Kollision");
			isAir = false;
		}
	}
	void OnCollisionExit (Collision col){
		if (col.gameObject.tag == "Terrain") {
			isAir = true;
			//print ("isAir is true");
			timer = Time.time + cooldown;
		}
	}
}
