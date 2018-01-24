using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Blob : MonoBehaviour {

	public Transform clonePrefab;

	public float diameter{
		get { return radius*2f;}
		set { radius = value / 2f;}
	}
	public float radius;

	public float volume{		
		get { 		
			return computeVolume(radius);}
		set {
			radius = computeRadius(value);
		}
	}


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (radius <= 0) {
			Destroy (this);
			return;
		}

		//Adjust size if necessary
		if (transform.localScale.x != diameter) {
			transform.localScale = new Vector3 (diameter, diameter, diameter);

			//Adjust y position if necessary
			if (transform.position.y - radius < 0) {
				transform.position = new Vector3 (transform.position.x, transform.position.y + radius, transform.position.z);
			}

			GetComponent<Rigidbody> ().mass =  volume;
		}
	}


	public static float computeVolume(float radius){
		return 4f/3f * Mathf.PI * Mathf.Pow (radius, 3f);
	}

	public static float computeRadius(float volume){
		return Mathf.Pow((3f/4f) * (volume/Mathf.PI), 1f/3f);
	}

	/**
	 * Spawns a clone with the given radius. 
	 * The parent blobs volume will be reduced accordingly.
	 * 
	 * **/
	public void spawnClone(float cloneRadius){
		float cloneVolume = computeVolume (cloneRadius);

		if (volume - cloneVolume < 0) {
			DestroyImmediate (this.gameObject);
			return;
		} else {
			this.volume = this.volume - cloneVolume;

			float offset = radius + cloneRadius;
			Transform clone = Instantiate (clonePrefab, new Vector3 (transform.position.x - offset, transform.position.y, transform.position.z - offset), Quaternion.identity);
			clone.GetComponent<Blob> ().radius = cloneRadius;

		}
	}
}
