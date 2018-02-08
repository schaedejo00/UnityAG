using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwaningManager : MonoBehaviour {

	public float minPositionx;
	public float maxPositionx;
	public float minPositionz;
	public float maxPositionz;
	public GameObject blooberingPrefab;
	public Follower follower;

	private float randompositionx;
	private float randompositionz;
	private Transform spawnPosition;

	// Use this for initialization
	void Start () {
		randompositionx = Random.Range (transform.position.x - minPositionx,transform.position.x + maxPositionx);
		randompositionz = Random.Range (transform.position.z - minPositionz,transform.position.z + maxPositionz);
		GameObject bloobering = Instantiate (blooberingPrefab);
		bloobering.transform.position = new Vector3(randompositionx, 1.4f, randompositionz);
		print (randompositionx);
		follower.target = bloobering.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
}
