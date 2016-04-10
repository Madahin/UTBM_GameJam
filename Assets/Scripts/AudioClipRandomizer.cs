using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioClipRandomizer : MonoBehaviour {

    private AudioSource _audioSource;

    public List<AudioClip> Clips;

	// Use this for initialization
	void Start () {
        
        _audioSource = GetComponent<AudioSource>();

        setClip();
	}
	
    void setClip()
    {
        int rng = Mathf.FloorToInt(Random.Range(0.0f, 100.0f * (Clips.Count - 1))) % Clips.Count;

        _audioSource.clip = Clips[rng];
        _audioSource.Play();

    }

    private bool checkClip = true;

	// Update is called once per frame
	void Update () {
        if (!_audioSource.isPlaying && checkClip)
        {
            checkClip = false;
            StartCoroutine(playDelayed());
        }
            
	}


    private IEnumerator playDelayed()
    {
        yield return new WaitForSeconds(Random.Range(2.0f, 5.0f));
        checkClip = true;
        setClip();
    }
}
