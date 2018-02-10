using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
	public float rotationSpeedX = 50;
	private float xRot;
	
	// Update is called once per frame
	void Update () {
		xRot = Input.GetAxis("Mouse Y") * -rotationSpeedX * Time.deltaTime;
		transform.Rotate(xRot, 0, 0);
		if (transform.eulerAngles.x < 280)
		{
			Vector3 newRotation = new Vector3(283, transform.eulerAngles.y, transform.eulerAngles.z);
			transform.rotation = Quaternion.Euler(newRotation);
		}
		if (transform.eulerAngles.x > 355)
		{
			Vector3 newRotation = new Vector3(353, transform.eulerAngles.y, transform.eulerAngles.z);
			transform.rotation = Quaternion.Euler(newRotation);
		}
	}
}
