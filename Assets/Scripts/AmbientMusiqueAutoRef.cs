using UnityEngine;
using System.Collections;

public class AmbientMusiqueAutoRef : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameManager.Instance.ambientMusic = this.gameObject;
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
