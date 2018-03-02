using UnityEngine;
using System.Collections;
using Helper;

public class PlayerShooting : MonoBehaviour {

	public GameObject projectil;
	public Transform shootPosition;
	public KeyCode shooting;
	public float range = 10;
	public float defaultCooldown;
	
	private Cooldown cooldown = new Cooldown();

	void Start(){
		cooldown.delay = defaultCooldown;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (shooting)) {
			if (cooldown.isNextEvent()) {
				Fire();
				cooldown.calcNextEvent();
			}
		}
	
	}
	void Fire()
	{
		GameObject shell = Instantiate(projectil);
		shell.GetComponent<DamageManager>().owner = this.gameObject;
		shell.transform.position = shootPosition.position;
		shell.transform.rotation = shootPosition.rotation;
		shell.GetComponent<Rigidbody>().AddForce(shootPosition.forward.normalized * range);
	}
}
