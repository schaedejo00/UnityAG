using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwaningManager : MonoBehaviour {

	public float timeBetweenSpawns = 0f;
	public float spawnNumber;
	public bool startSpawn;
	public bool useRandomPosition;
	public float minPositionX;
	public float maxPositionX;
	public float minPositionZ;
	public float maxPositionZ;
	public GameObject blooberingPrefab;
	public Follower follower;

	private Transform spawnPosition;
	struct Timer
	{
		public bool enabled;
		public float nextEvent;
		public float timeBetweenSpawns;
	}
	[System.Serializable]
	public struct Point
	{
		public float x, y,z;
	}
	public Point spawnPoint = new Point();
	private Point random = new Point();
	private Timer timing = new Timer();
	// Use this for initialization
	void Start () {
		timing.timeBetweenSpawns = timeBetweenSpawns;
		if (timing.timeBetweenSpawns > 0f) {
			timing.nextEvent = Time.time + timing.timeBetweenSpawns;
			timing.enabled = true;
		} else {
			timing.enabled = false;
		}
	}
	// Update is called once per frame 
	void Update () {
		if (timing.enabled) {
			if (Time.time > timing.nextEvent || startSpawn||spawnNumber > 0) {
				timing.nextEvent = Time.time + timing.timeBetweenSpawns;
				if (useRandomPosition) {
					
					random.x = Random.Range (transform.position.x - minPositionX, transform.position.x + maxPositionX);
					random.z = Random.Range (transform.position.z - minPositionZ, transform.position.z + maxPositionZ);
					GameObject bloobering = Instantiate (blooberingPrefab);
					bloobering.transform.position = new Vector3 (random.x, 1.4f, random.z);
					follower.target = bloobering.transform;
				} else {
					GameObject bloobering = Instantiate (blooberingPrefab);
					bloobering.transform.position = new Vector3 (spawnPoint.x, 1.4f, spawnPoint.z);
					follower.target = bloobering.transform;
				}
				print (random.x);
				if (startSpawn) {
					startSpawn = false;
				}
				if (spawnNumber > 0) {
					spawnNumber--;
				}
			}
		}
		else{ 
			if (startSpawn == true || spawnNumber > 0) {
				if (useRandomPosition) {
					random.x = Random.Range (transform.position.x - minPositionX, transform.position.x + maxPositionX);
					random.z = Random.Range (transform.position.z - minPositionZ, transform.position.z + maxPositionZ);
					GameObject bloobering = Instantiate (blooberingPrefab);
					bloobering.transform.position = new Vector3 (random.x, 1.4f, random.z);
					follower.target = bloobering.transform;
				}else {
					GameObject bloobering = Instantiate (blooberingPrefab);
					bloobering.transform.position = new Vector3 (spawnPoint.x, 1.4f, spawnPoint.z);
					follower.target = bloobering.transform;
				}
				if (startSpawn) {
					startSpawn = false;
				}
				if (spawnNumber > 0) {
					spawnNumber--;
				}
			}
		}
	}
}
