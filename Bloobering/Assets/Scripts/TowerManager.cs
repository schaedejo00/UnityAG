using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helper;

public class TowerManager : MonoBehaviour {
    
    public Texture blueTexture;
	public Texture redTexture;
	public States firstPlayerStay = States.NONE;
	public bool firstPlayerChange = false;

	private States secondPlayerStay =States.NONE;
	private string newPlayer;
	private States towerOwner = States.NONE;



	private MeshRenderer meshRenderer;
	private Renderer rend;
	private bool playerStay;

	// Use this for initialization

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (towerOwner == States.NONE)
            {
                towerOwner = Helpers.StateFromGameObject(col.gameObject);
            }
            if (firstPlayerStay == States.NONE)
            {
                firstPlayerStay = Helpers.StateFromGameObject(col.gameObject);
                firstPlayerChange = false;
            }
        }
    }
    void OnTriggerStay (Collider col){
		if (GetComponent<TowerCountdown>().textureChanger == true) {
			if (firstPlayerStay==States.BLUE) {
				GetComponentInChildren<MeshRenderer> ().material.mainTexture = blueTexture;
			}

			if (firstPlayerStay == States.RED) {
				GetComponentInChildren<MeshRenderer> ().material.mainTexture = redTexture;
			}
		}
	}
	void OnTriggerExit (Collider col){
		if (secondPlayerStay == Helpers.StateFromGameObject( col.gameObject)) {
			secondPlayerStay =States.NONE;
		}
		if (firstPlayerStay == Helpers.StateFromGameObject(col.gameObject)) {
			firstPlayerStay = secondPlayerStay;
			firstPlayerChange = true;
			secondPlayerStay = States.NONE;
            playerStay = true;
		}
	}
    
}

