using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class NetworkDamageManager :NetworkBehaviour {
	[SyncVar]
	public int damage=10;
	private float time;
	private void Start()
	{
		time = Time.time;
	}
	public GameObject owner;
	void OnCollisionEnter (Collision col){
		LiveManager liveManager = col.gameObject.GetComponent<LiveManager> ();
		//Debug.Log (liveManager);
		Debug.Log(col.collider.name);
		if (liveManager != null) {
			liveManager.takeDamage(damage);
			}
		}
	private void OnDestroy()
	{
		Debug.Log(Time.time - time);
	}
}
