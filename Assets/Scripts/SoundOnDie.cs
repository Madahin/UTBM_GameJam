using UnityEngine;
using System.Collections;

public class SoundOnDie : MonoBehaviour {

    public AudioClip[] Clips;
    private AudioSource _audioSource;

    // Use this for initialization
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	public void Play () {
        if (!_audioSource.isPlaying)
        {
            int rng = Mathf.FloorToInt(Random.Range(0.0f, 100.0f * (Clips.Length - 1))) % Clips.Length;
            _audioSource.clip = Clips[rng];
            _audioSource.Play();
        }
	}
}
