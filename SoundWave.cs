using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWave : MonoBehaviour {

    private AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        if (GameController.gameEnded) {
            GetComponent<Animator>().enabled = false;
        } else {
            GetComponent<Animator>().enabled = true;
        }
    }

    void PlaySound() {
        audioSource.Play();
    }
}
