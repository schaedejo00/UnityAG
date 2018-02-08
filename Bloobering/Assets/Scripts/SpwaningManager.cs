using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwaningManager : MonoBehaviour {

	public float timerTime = 0f;
	public float spawnNumber;
	public bool startSpawn;
	public bool spawn;
	public bool randomPosition;
	public float positionZ;
	public float positionX;
	public float minPositionX;
	public float maxPositionX;
	public float minPositionZ;
	public float maxPositionZ;
	public GameObject blooberingPrefab;
	public Follower follower;

	private float randompositionx;
	private float randompositionz;
	private float timer;
	private bool trueTimer;
	private Transform spawnPosition;

	// Use this for initialization
	void Start () {
		if (timerTime > 0f) {
			trueTimer = true;
			timer = Time.time + timerTime;
		} else {
			trueTimer = false;
		}
	}
	// Update is called once per frame
	void Update () {
		if (trueTimer == true) {
			if (Time.time > timer||startSpawn == true||spawn == true||spawnNumber > 0) {
				timer = Time.time + timerTime;
				if (randomPosition == true) {
					randompositionx = Random.Range (transform.position.x - minPositionX, transform.position.x + maxPositionX);
					randompositionz = Random.Range (transform.position.z - minPositionZ, transform.position.z + maxPositionZ);
					GameObject bloobering = Instantiate (blooberingPrefab);
					bloobering.transform.position = new Vector3 (randompositionx, 1.4f, randompositionz);
					follower.target = bloobering.transform;
				} else {
					GameObject bloobering = Instantiate (blooberingPrefab);
					bloobering.transform.position = new Vector3 (positionX, 1.4f, positionZ);
					follower.target = bloobering.transform;
				}
				print (randompositionx);
				if (startSpawn == true) {
					startSpawn = false;
				}
				if (spawn == true) {
					spawn = false;
				}
				if (spawnNumber > 0) {
					spawnNumber = spawnNumber - 1;
				}
			}
		}
		else{ 
			if (startSpawn == true || spawn == true||spawnNumber > 0) {
				if (randomPosition == true) {
					randompositionx = Random.Range (transform.position.x - minPositionX, transform.position.x + maxPositionX);
					randompositionz = Random.Range (transform.position.z - minPositionZ, transform.position.z + maxPositionZ);
					GameObject bloobering = Instantiate (blooberingPrefab);
					bloobering.transform.position = new Vector3 (randompositionx, 1.4f, randompositionz);
					follower.target = bloobering.transform;
				}else {
					GameObject bloobering = Instantiate (blooberingPrefab);
					bloobering.transform.position = new Vector3 (positionX, 1.4f, positionZ);
					follower.target = bloobering.transform;
				}
				if (startSpawn == true) {
					startSpawn = false;
				}
				if (spawn == true) {
					spawn = false;
				}
				if (spawnNumber > 0) {
					spawnNumber = spawnNumber - 1;
				}
			}
		}
	}
}
