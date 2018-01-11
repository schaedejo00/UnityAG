using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveManager : MonoBehaviour {
	
	public int Health;
	public Transform shootPosition;
	public Renderer[] renderers;

	public delegate void Death ();
	public event Death onDeath;

	void Update () {
		if (Health <= 0) {
			Debug.Log ("Dead");
			onDeath ();
		}
	}

}