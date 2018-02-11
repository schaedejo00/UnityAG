using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class NetworkDamageManager :NetworkBehaviour {
	[SyncVar]
	public int damage=10;

	void OnCollisionEnter (Collision col){
		LiveManager liveManager = col.gameObject.GetComponent<LiveManager> ();
		//Debug.Log (liveManager);
		if (liveManager != null) {
			liveManager.takeDamage(damage);
			}
		}
}
