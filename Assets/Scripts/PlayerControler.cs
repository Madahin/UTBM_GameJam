using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {

    [Range(0.0f, 10.0f)]
    public float MoveSpeedFactor = 0.5f;

    [Range(0.0f, 10.0f)]
    public float MouseSpeedFactor = 1.5f;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.Translate(Input.GetAxis("Horizontal") * MoveSpeedFactor,
                                       0f,
                                       Input.GetAxis("Vertical") * MoveSpeedFactor);

        gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                    0f,
                                                    gameObject.transform.position.z);

        gameObject.transform.Rotate(-Input.GetAxis("Mouse Y") * MouseSpeedFactor, 0f, 0f);
        gameObject.transform.Rotate(0f, Input.GetAxis("Mouse X") * MouseSpeedFactor, 0f);

        float gimbalLock = gameObject.transform.rotation.eulerAngles.x;

        if (gimbalLock >= 269 && gimbalLock < 275)
        {
            gimbalLock = 275f;
        }

        if(gimbalLock >= 87 && gimbalLock < 91)
        {
            gimbalLock = 88f;
        }

        gameObject.transform.rotation = Quaternion.Euler(gimbalLock,
                                                         gameObject.transform.rotation.eulerAngles.y,
                                                         0f);

    }
}
