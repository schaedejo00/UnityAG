using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkRotate : MonoBehaviour {
	public float rotationSpeedX = 50;
	private float xRot;
	
	// Update is called once per frame
	void Update () {
		if (!transform.GetComponentInParent<NetworkPlayerMovement>().isLocalPlayer)
		{
			return;
		}
		xRot = Input.GetAxis("Mouse Y") * -rotationSpeedX * Time.deltaTime;
		transform.Rotate(xRot, 0, 0);
		if (transform.eulerAngles.x < 280)
		{
			Vector3 newRotation = new Vector3(280, transform.eulerAngles.y, transform.eulerAngles.z);
			transform.rotation = Quaternion.Euler(newRotation);
		}
		if (transform.eulerAngles.x > 350)
		{
			Vector3 newRotation = new Vector3(350, transform.eulerAngles.y, transform.eulerAngles.z);
			transform.rotation = Quaternion.Euler(newRotation);
		}
	}
}
