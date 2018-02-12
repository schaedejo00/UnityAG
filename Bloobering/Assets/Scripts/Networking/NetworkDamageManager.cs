using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class NetworkDamageManager :NetworkBehaviour {
	[SyncVar]
	public int damage=50;
	public GameObject explosion;
	public float duration = 1F;
	public GameObject owner;
	private Color ownerColor;
	[SyncVar]
	public float r,g,b;
	void OnCollisionEnter (Collision col){
		if (explosion != null)
		{
			CmdExplode();
		}
		
		NetworkLiveManager liveManager = col.gameObject.GetComponent<NetworkLiveManager> ();
		//Debug.Log (liveManager);
		//Debug.LogError("Treffer");
		if (liveManager != null) {
			liveManager.takeDamage(damage);
			}
		Destroy(this.gameObject);
		}
	
	void CmdExplode()
	{
		GameObject explosionAnimation = Instantiate(explosion);
		explosionAnimation.transform.position = transform.position;

		explosionAnimation.GetComponent<ParticleSystemRenderer>().material.color = new Color(r,g,b);
		NetworkServer.Spawn(explosionAnimation);
		Destroy(explosionAnimation, duration);
	}
}
