using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class NetworkDamageManager :NetworkBehaviour {
	[SyncVar]
	public int damage=50;
	public float duration = 1F;
	public GameObject owner;
	private Color ownerColor;
	void OnCollisionEnter (Collision col){
		
		NetworkLiveManager liveManager = col.gameObject.GetComponent<NetworkLiveManager> ();
		//Debug.Log (liveManager);
		//Debug.LogError("Treffer");
		if (liveManager != null) {
			liveManager.takeDamage(damage);
			}
		Destroy(this.gameObject);
		}
	
	
}
