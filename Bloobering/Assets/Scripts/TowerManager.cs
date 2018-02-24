using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour {

	public Texture blueTexture;
	public Texture redTexture;
	public string firstPlayerStay = "false";
	public bool firstPlayerChange = false;

	private string secondPlayerStay = "false";
	private string newPlayer;
	private string towerOwner = "false";

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		//GetComponent<TowerCountdown> ();

	}
	void OnTriggerEnter (Collider col){
		if (col.gameObject.tag == "Player") {
			if (towerOwner == "false") {
				towerOwner = col.gameObject.name;
			}
			if (firstPlayerStay == "false") {
				firstPlayerStay = col.gameObject.name;
				firstPlayerChange = false;
			}
		}
	}
	void OnTriggerStay (Collider col){
		if (GetComponent<TowerCountdown>().textureChanger == true) {
			if ("Sphere_blue" == firstPlayerStay) {
				GetComponentInChildren<MeshRenderer> ().material.mainTexture = blueTexture;
			}

			if ("Sphere_red" == firstPlayerStay) {
				GetComponentInChildren<MeshRenderer> ().material.mainTexture = redTexture;
			}
		}
	}
	void OnTriggerExit (Collider col){
		if (secondPlayerStay == col.gameObject.name) {
			secondPlayerStay = "false";
		}
		if (firstPlayerStay == col.gameObject.name) {
			firstPlayerStay = secondPlayerStay;
			firstPlayerChange = true;
			secondPlayerStay = "false";
		}
	}
}

