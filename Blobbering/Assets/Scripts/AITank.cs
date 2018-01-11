using UnityEngine;

public class AITank : MonoBehaviour {

	public Vector2 searchBoxMinPosition;
	public Vector2 searchBoxMaxPosition;
	public float patrolCooldown;

	private UnityEngine.AI.NavMeshAgent navi;
	private float patrolTimer;

	void Start(){
		navi = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}

	void Update () {
		if (patrolTimer < Time.time) {
			navi.SetDestination (getRandomPositionInBox ());
			patrolTimer = Time.time + patrolCooldown;
		}
	}

	private Vector3 getRandomPositionInBox(){
		float x = Random.Range (searchBoxMinPosition.x, searchBoxMaxPosition.x);
		float y = Random.Range (searchBoxMinPosition.y, searchBoxMaxPosition.y);
		return new Vector3 (x, 0, y);
	}
}
