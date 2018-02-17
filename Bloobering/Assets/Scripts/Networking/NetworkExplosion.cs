using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class NetworkExplosion : NetworkBehaviour {

    public float cooldown;
    private float timer;
    [SyncVar]
    public float r, g, b;
    Color color;
    Transform Position;

    // Use this for initialization
    void Start () {
        timer = Time.time + cooldown;
        color = new Color(r, g, b);
        gameObject.GetComponent<ParticleSystemRenderer>().material.color = color;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= timer)
        {
            Destroy(gameObject);
        }
    }
}
