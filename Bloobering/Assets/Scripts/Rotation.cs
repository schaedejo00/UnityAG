using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {
	public float rotationSpeedX = 50;
	private float xRot;
	private float startTimer;
	// Use this for initialization
	void Start () {
		startTimer = Time.time +3;
	}
	
	// Update is called once per frame
	void Update(){
			xRot = Input.GetAxis ("Mouse Y") * rotationSpeedX * Time.deltaTime;
			Vector3 newRotation = new Vector3 (Mathf.Clamp (transform.eulerAngles.x - xRot, 280, 360), transform.eulerAngles.y, transform.eulerAngles.z);
			transform.rotation = Quaternion.Euler (newRotation);
			}
}
