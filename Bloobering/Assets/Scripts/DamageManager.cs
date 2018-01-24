﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageManager : MonoBehaviour {
	public int damage;
	public GameObject levelreloader;
	public GameObject owner;
	private Color startColor;
	// Use this for initialization
	void Start () {
		startColor = GetComponent<Renderer>().material.color;
	}

	void OnCollisionEnter (Collision col){
		LiveManager liveManager = col.gameObject.GetComponent<LiveManager> ();
		Debug.Log (liveManager);
		if (liveManager != null) {
			liveManager.Health -= damage;
				if (liveManager.Health > 0) {
					for (int i = 0; i < liveManager.renderers.Length / liveManager.Health - 1; i++) {
						liveManager.renderers [Random.Range (0, liveManager.renderers.Length)].material.color = startColor;
					}
				} else {
					for (int i = 0; i < liveManager.renderers.Length; i++) {
						liveManager.renderers [i].material.color = startColor;
					}
				GameObject.Find ("Text").GetComponent<Text> ().text = owner.name + " gewinnt!";
					GameObject levelreload = Instantiate (levelreloader);
				}
			}
		}
}
