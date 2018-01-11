using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelreloader : MonoBehaviour {
	private float cooldown;
	private float timer;

	// Use this for initialization
	void Start () {
		cooldown = 3;
		timer = Time.time + cooldown;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= timer) {
			Application.LoadLevel ("AI vs Player");
		}
	}
}
