using UnityEngine;
using System.Collections;

public class PlayerStalker : MonoBehaviour {

	public GameObject player;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (player.transform.position.x, 1, -10f);
	}
}
