using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkCatapultTrap : NetworkBehaviour {
	[SyncVar]
	private bool alreadyActivated=false;

    public Vector3 power;
    public float extraBoost;

    [SerializeField]
    private int damage;

    public bool playSound;
    public AudioClip trapSound;
    [SerializeField]
    private Animator animator;
    private AudioSource audioSource;


    void OnTriggerEnter(Collider col) {
        if (!alreadyActivated) {
			if (col == null)
			{
				return;
			}
            GameObject player = col.gameObject;

            if (player.tag == "Player") {
                Rigidbody rigidbody = player.GetComponent<Rigidbody>();
                player.GetComponent<NetworkLiveManager>().takeDamage(damage);
                animator.SetTrigger("Triggered");
                alreadyActivated = true;
				if (rigidbody != null) {
                    rigidbody.AddForce(power * extraBoost, ForceMode.Impulse);

                    //TODO: REMOVE LIFE
                }

                //Sounds
                if (playSound) {
                    audioSource = GetComponent<AudioSource>();

                    if (!audioSource.isPlaying) {
                        audioSource.clip = trapSound;
                        audioSource.volume = 0.5f;
                        audioSource.Play();
                    }
                }
            }
        }
    }
}