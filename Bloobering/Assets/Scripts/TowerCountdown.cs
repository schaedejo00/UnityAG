using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helper;

public class TowerCountdown : MonoBehaviour {

    public bool textureChanger = false;
    public float cooldown;
    public float exitTimerPerSecond;

    private Renderer rend;
    private bool playerStay = false;
    private float timer;
    private DualCooldown conquer;//Erobern
    private float pauseCooldown;
    private float pauseCooldownTimer;

    // Use this for initialization
    void Start () {
        conquer.normalDelay = cooldown;
        conquer.blockedDelay = cooldown;
    }

    void Update () {
		if (GetComponent<TowerManager> ().firstPlayerChange == true) {
            timer = 2 * Time.time + 2 * cooldown - timer;

            GetComponent<TowerManager> ().firstPlayerChange = false;
			Debug.Log ("Countdown_restarted");
		}

	}

    void OnTriggerEnter (Collider col){
		    if (Helpers.StateFromGameObject(col.gameObject) == GetComponent<TowerManager>().firstPlayerStay) {
		        playerStay = true;
                conquer.calcNextEvent();
	    }
    }

    void OnTriggerStay (Collider col){
		    if (col.gameObject.tag == "Player") {
			    if (conquer.isNextEvent()) {
				    textureChanger = true;
			    }
		    }
	    }

    void OnTriggerExit (Collider col){
		if (Helpers.StateFromGameObject(col.gameObject) == GetComponent<TowerManager>().firstPlayerStay) {
		    playerStay = false;
            conquer.blockCooldown();
	    }
    }
}
