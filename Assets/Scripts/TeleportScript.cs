using UnityEngine;
using System.Collections;

public class TeleportScript : MonoBehaviour {

    public string level;

	// Use this for initialization
	void Start () {
	
	}
	
    public void Teleport()
    {
        GameManager.Instance.LoadLevel(level);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Teleport();
        }
    }
}
