using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetworkPlayerShooting :NetworkBehaviour {

	public GameObject projectil;
	public Transform shootPosition;
	public KeyCode shooting;
	public float range = 40;
	public float defaultCooldown;
	public float destroyShootAfter = 3F;
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
		if (!isLocalPlayer)
		{
			return;
		}
		if (Input.GetKey (shooting)) {
			if (Time.time > cooldown.nextShot) {
				CmdFire();
                //Debug.LogError("Shooting");
				cooldown.calcNextShoot();
			}
		}
	
	}
	[Command]
	void CmdFire()
	{
		GameObject shell = Instantiate(projectil, shootPosition.position, shootPosition.rotation);
		shell.GetComponent<NetworkDamageManager>().owner = this.gameObject;
		Color pcolor = GetComponent<NetworkPlayerMovement>().PlayerColor;
		
		shell.GetComponent<NetworkSelfDestruct>().r = pcolor.r;
		shell.GetComponent<NetworkSelfDestruct>().g = pcolor.g;
		shell.GetComponent<NetworkSelfDestruct>().b = pcolor.b;
		shell.GetComponent<Rigidbody>().velocity=shootPosition.transform.forward.normalized * range;
		NetworkServer.Spawn(shell);
	}
}
