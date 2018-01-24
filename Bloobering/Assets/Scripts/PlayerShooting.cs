using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public GameObject shellPrefab;
	public Transform shootPosition;
	public KeyCode shooting;
	public float range = 10;
	public float defaultCooldown;
	private float cooldown;
	private float timer;

	void Start(){
		cooldown = defaultCooldown;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (shooting)) {
			if (Time.time > timer) {
				GameObject shell = Instantiate (shellPrefab);
				shell.GetComponent<DamageManager> ().owner = this.gameObject;
				shell.transform.position = shootPosition.position;
				shell.transform.rotation = shootPosition.rotation;
				shell.GetComponent<Rigidbody> ().AddForce (shootPosition.forward.normalized * range);
				timer = Time.time + cooldown;
			}
		}
	
	}
}
