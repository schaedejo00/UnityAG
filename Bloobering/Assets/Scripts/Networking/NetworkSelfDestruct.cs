using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class NetworkSelfDestruct :NetworkBehaviour {

	public float cooldown;
	private float timer;
	public GameObject shellExplosion;
	[SyncVar]
	public float r, g, b;
    Color color; 
    Transform Position;

	// Use this for initialization
	void Start () {
		timer = Time.time + cooldown;
        color = new Color(r, g, b);
        gameObject.GetComponent<MeshRenderer>().material.color = color;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= timer) {
			Destroy (gameObject);
		}
	}
	void OnCollisionEnter (Collision col){
        
        GameObject explosion = Instantiate (shellExplosion);
        explosion.GetComponent<NetworkExplosion>().r = color.r;
        explosion.GetComponent<NetworkExplosion>().g = color.g;
        explosion.GetComponent<NetworkExplosion>().b = color.b;
        explosion.transform.position = transform.position;
		
		NetworkServer.Spawn(explosion);

		if (col.gameObject.tag == "Player") {
			timer = Time.time + 0.1f;
			Destroy (gameObject);
		} else {
			Destroy (gameObject);
		}
	}
}
