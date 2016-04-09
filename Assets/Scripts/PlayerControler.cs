using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {

    [Range(0.0f, 10.0f)]
    public float MoveSpeedFactor = 0.5f;

    [Range(0.0f, 10.0f)]
    public float MouseSpeedFactor = 0.5f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(Input.GetAxis("Horizontal") * MoveSpeedFactor,
                                       0f,
                                       Input.GetAxis("Vertical") * MoveSpeedFactor);

        gameObject.transform.Rotate(-Input.GetAxis("Mouse Y"),
                                    Input.GetAxis("Mouse X"),
                                    0f);

	}
}
