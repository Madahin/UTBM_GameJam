using UnityEngine;
using System.Collections;

public class CadreVieAutoRef : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameManager.Instance.CadreVie = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
