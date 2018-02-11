using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public GameObject projectil;
	public Transform shootPosition;
	public KeyCode shooting;
	public float range = 10;
	public float defaultCooldown;
	struct Cooldown
	{
		public bool enabled;
		public float nextShot;
		public float delay;
		public float calcNextShoot()
		{
			nextShot = Time.time + delay;
			return nextShot;
		}
	}
	private Cooldown cooldown = new Cooldown();

	void Start(){
		cooldown.delay = defaultCooldown;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (shooting)) {
			if (Time.time > cooldown.nextShot) {
				Fire();
				cooldown.calcNextShoot();
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
