using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetworkPlayerShooting :NetworkBehaviour {

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
		//shootPosition= gameObject.transform.GetChild(0).GetChild(0).transform;
	}

	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer)
		{
			return;
		}
		if (Input.GetKey (shooting)) {
			if (Time.time > cooldown.nextShot) {
				CmdFire();
				cooldown.calcNextShoot();
			}
		}
	
	}
	[Command]
	void CmdFire()
	{
		GameObject shell = Instantiate(projectil);
		shell.GetComponent<NetworkDamageManager>().owner = this.gameObject;
		Vector3 pos = shootPosition.position;
		//pos.x = pos.x + 1;
		//pos.y = pos.y + 1;
		//pos.z = pos.z + 1;
		shell.transform.position = pos;
		shell.transform.rotation = shootPosition.rotation;
		shell.GetComponent<Rigidbody>().AddForce(shootPosition.forward.normalized * range);
		NetworkServer.Spawn(shell);
	}
}
