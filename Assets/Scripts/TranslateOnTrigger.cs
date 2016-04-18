using UnityEngine;
using System.Collections;

public class TranslateOnTrigger : MonoBehaviour {

    public GameObject obj;

    private bool triggered = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(triggered)
        {
            obj.transform.position = Vector3.Lerp(obj.transform.position, new Vector3(obj.transform.position.x, 17.5f, obj.transform.position.z), Time.deltaTime * 10);
        }
	}


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            triggered = true;
        }
    }
}
