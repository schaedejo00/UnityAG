using UnityEngine;
using System.Collections;

public class GroundDetector : MonoBehaviour {

	private bool onGround = true;

	void OnColissionStart (Collider ground) {
		onGround = true;

	}
	
	// Update is called once per frame
	void OnColissionExit (Collider ground) {
		onGround = false;
	}

	public bool isOnGround(){
		return onGround;
	}
}
