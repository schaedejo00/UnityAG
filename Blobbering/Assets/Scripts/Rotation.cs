using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {
	public float RotationSpeedx = 50;
	private float xrot;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		xrot = (Input.GetAxis ("Mouse Y") * RotationSpeedx * Time.deltaTime);
		transform.eulerAngles = new Vector3(transform.eulerAngles.x - xrot, transform.eulerAngles.y, transform.eulerAngles.z);
		print (transform.rotation.x);
	}
}
		
