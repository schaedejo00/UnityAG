using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetSelfDestruct :NetworkBehaviour {

	public float cooldown;
	private float timer;
	public GameObject shellExplosion;
	[SyncVar]
	public float r, g, b;
	Transform Position;

	// Use this for initialization
	void Start () {
		timer = Time.time + cooldown;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= timer) {
			Destroy (gameObject);
		}
	}
	void OnCollisionEnter (Collision col){
		
		GameObject explosion = Instantiate (shellExplosion);
		explosion.transform.position = transform.position;
		explosion.GetComponent<ParticleSystemRenderer>().material.color = new Color(r, g, b);
		NetworkServer.Spawn(explosion);

		if (col.gameObject.tag == "Player") {
			timer = Time.time + 0.1f;
			Destroy (gameObject);
		} else {
			Destroy (gameObject);
		}
	}
}
