using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour {

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
		pauseCooldown = cooldown + 1;
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

			if (cooldown >= pauseCooldown + exitTimerPerSecond) {
				if (Time.time > pauseCooldownTimer) {
					//Debug.Log ("Pause_Cooldown_wurde_erhöt");
					pauseCooldown = pauseCooldown + exitTimerPerSecond;
					pauseCooldownTimer = Time.time + 1;
				}
			} else {
				pauseCooldown = cooldown;
			}

		}
	}

	void OnTriggerEnter (Collider col){
		playerStay = true;
		if (col.gameObject.tag == "Player") {
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
			pauseCooldownTimer = Time.time + 1;
		}
	}
}
