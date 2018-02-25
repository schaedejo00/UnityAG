using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour {

<<<<<<< HEAD
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

=======
	public Texture textures;
	public float cooldown;
	public float exitTimerPerSecond;

	private MeshRenderer meshRenderer;
	private Renderer rend;
	private bool playerStay;
	private float timer;
	private float pauseCooldown;
	private float pauseCooldownTimer;

	// Use this for initialization
	void Start () {
		pauseCooldown = cooldown;
	}
	//timer - Time.time
	// Update is called once per frame
	void Update () {
		if (timer - Time.time > 0) {
			if (playerStay == false) {
				Debug.Log (pauseCooldown);
			} else {
				Debug.Log (timer - Time.time);
			}
		}

		if (playerStay == false) {
			if (cooldown > pauseCooldown + exitTimerPerSecond) {
				if (Time.time > pauseCooldownTimer) {
					pauseCooldown = pauseCooldown + exitTimerPerSecond;
					timer = Time.time + pauseCooldown;
					pauseCooldownTimer = Time.time + 1;
				}
			} else {
				pauseCooldown = cooldown;
			}
		}
>>>>>>> de09e9973f093bd1aceb807a3aa9781ab6f7b3aa
	}

	void OnTriggerEnter (Collider col){
		if (col.gameObject.tag == "Player") {
<<<<<<< HEAD
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
=======
			playerStay = true;
			if (pauseCooldown < cooldown) {
				timer = Time.time + pauseCooldown;
			} else {
				timer = Time.time + cooldown;
			}
		}
	}

	void OnTriggerStay (Collider col){
		if (col.gameObject.tag == "Player"){
			if (Time.time >= timer) {
				GetComponentInChildren<MeshRenderer> ().material.mainTexture = textures;
			}
		}
	}

	void OnTriggerExit (Collider col){
		if (col.gameObject.tag == "Player") {
			playerStay = false;
			pauseCooldown = timer - Time.time;
			pauseCooldownTimer = Time.time;
>>>>>>> de09e9973f093bd1aceb807a3aa9781ab6f7b3aa
		}
	}
}

