using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultTrap : MonoBehaviour {

	private bool alreadyActivated;

    public Vector3 power;
    public float extraBoost;

    public bool playSound;
	[SerializeField]
	private int damage;
    public AudioClip trapSound;
    private AudioSource audioSource;

	[SerializeField]
	private Animator animator;

    void OnTriggerEnter(Collider col) {
		if (alreadyActivated != true) {
            alreadyActivated = true;
            GameObject player = col.gameObject;

            if (player.tag == "Player") {
                Rigidbody rigidbody = player.GetComponent<Rigidbody>();
				animator.SetTrigger ("Triggered");
                if (rigidbody != null) {
                    rigidbody.AddForce(power * extraBoost, ForceMode.Impulse);
					player.GetComponent<LiveManager> ().takeDamage (damage);
                }

                //Sounds
                if (playSound == true) {
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