using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {

	public Transform target;
	public Vector3 offset;

	void LateUpdate () {
		if (target != null) {
			transform.position = target.position + offset;
			transform.RotateAround (target.position, Vector3.up, target.eulerAngles.y);
			transform.LookAt (target);
		} else {
			Destroy (this);		//I mean, if there is no target, there is no sense in keeping this script.
		}
	}
}
