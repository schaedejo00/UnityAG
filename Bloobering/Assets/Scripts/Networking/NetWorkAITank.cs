using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.AI;
public class NetAITank : NetworkBehaviour {

	public Vector2 searchBoxMinPosition;
	public Vector2 searchBoxMaxPosition;
	public float patrolCooldown;

	private NavMeshAgent navi;
	private float patrolTimer;
	[Server]
	void Start(){
		if (!isServer)
		{
			return;
		}
		navi = GetComponent<NavMeshAgent> ();
	}
	[Server]
	void Update () {
		if (!isServer)
		{
			return;
		}
		if (patrolTimer < Time.time) {
			navi.SetDestination (getRandomPositionInBox ());
			patrolTimer = Time.time + patrolCooldown;
		}
	}

	private Vector3 getRandomPositionInBox(){
		float x = Random.Range (searchBoxMinPosition.x, searchBoxMaxPosition.x);
		float y = Random.Range (searchBoxMinPosition.y, searchBoxMaxPosition.y);
		return new Vector3 (x, 1, y);
	}
}
