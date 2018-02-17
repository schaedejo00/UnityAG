using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour {

	public Texture textures;

	private MeshRenderer meshRenderer;
	private Renderer rend;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter (Collider col){
		//Debug.Log ("Berührung_erkannt");
		if (col.gameObject.tag == "Player"){
			//Debug.Log ("PLayer_erkannt");
			GetComponentInChildren<MeshRenderer>().material.mainTexture = textures;
		}
	}
}
