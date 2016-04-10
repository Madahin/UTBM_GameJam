using UnityEngine;
using System.Collections;

public class SoundOnStart : MonoBehaviour {

    public AudioClip audioClip;
    private AudioSource _audioSource;

    // Use this for initialization
    void Start () {
        _audioSource = GetComponent<AudioSource>();

        _audioSource.clip = audioClip;
        _audioSource.Play();
	}
}
