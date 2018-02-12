using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultTrap : MonoBehaviour {

    public bool alreadyActive;

    public Vector3 power;
    public float extraBoost;

    public bool playSound;
    public AudioClip trapSound;
    private AudioSource audioSource;

    void Start() {
        alreadyActive = true;
    }

    void OnTriggerEnter(Collider col) {
        if (alreadyActive != false) {
            alreadyActive = false;
            GameObject player = col.transform.parent.gameObject;

            if (player.tag == "Player") {
                Rigidbody rigidbody = player.GetComponent<Rigidbody>();

                if (rigidbody != null) {
                    rigidbody.AddForce(power * extraBoost, ForceMode.Impulse);

                    //TODO: REMOVE LIFE
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