using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCountdown : MonoBehaviour {

public bool textureChanger = false;
public float cooldown;
public float exitTimerPerSecond;

private Renderer rend;
private bool playerStay = false;
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
		if (GetComponent<TowerManager> ().firstPlayerChange == true) {
			timer = Time.time + cooldown + (cooldown-(timer - Time.time));
			GetComponent<TowerManager> ().firstPlayerChange = false;
			Debug.Log ("Countdown_restarted");
		}
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
	}

void OnTriggerEnter (Collider col){
		if (col.gameObject.name == GetComponent<TowerManager>().firstPlayerStay) {
		playerStay = true;
		if (pauseCooldown < cooldown) {
			timer = Time.time + pauseCooldown;
		} else {
			timer = Time.time + cooldown;
		}
	}
}

void OnTriggerStay (Collider col){
		if (col.gameObject.tag == "Player") {
			if (Time.time >= timer) {
				textureChanger = true;
			}
		}
	}

void OnTriggerExit (Collider col){
		if (col.gameObject.tag == GetComponent<TowerManager>().firstPlayerStay) {
		playerStay = false;
		pauseCooldown = timer - Time.time;
		pauseCooldownTimer = Time.time;
	}
}
}
