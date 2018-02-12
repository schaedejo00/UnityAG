using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class NetworkDamageManager :NetworkBehaviour {
	[SyncVar]
	public int damage=50;
	public GameObject explosion;
	private float time;
	public float duration = 1F;
	private void Start()
	{
		time = Time.time;
	}
	public GameObject owner;
	
	void OnCollisionEnter (Collision col){
		if (explosion != null)
		{
			GameObject explosionAnimation = Instantiate(explosion);
			explosionAnimation.transform.position = transform.position;
			explosionAnimation.GetComponent<ParticleSystemRenderer>().material.color = owner.GetComponent<NetworkPlayerMovement>().PlayerColor;
			Destroy(explosionAnimation, duration);
		}
		
		NetworkLiveManager liveManager = col.gameObject.GetComponent<NetworkLiveManager> ();
		//Debug.Log (liveManager);
		//Debug.LogError("Treffer");
		if (liveManager != null) {
			liveManager.takeDamage(damage);
			}
		Destroy(this.gameObject);
		}
}
