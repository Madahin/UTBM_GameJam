using UnityEngine;
using System.Collections;
using UnityEditor;

public class PlayerControler : MonoBehaviour {

    [Range(0.0f, 10.0f)]
    public float MoveSpeedFactor = 0.5f;

    [Range(0.0f, 10.0f)]
    public float MouseSpeedFactor = 1.5f;
    
    public float height = 1.5f;

    public float projectilForce = 30f;

    public GameObject m_projectile;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;
    public float thrust;

    void Awake()
    {
        GameManager.Instance.Player = this.gameObject;
    }

    // Use this for initialization
    void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
	}
	


    void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject projectile = GameObject.Instantiate(m_projectile, transform.position + transform.forward*2f, transform.rotation) as GameObject;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * projectilForce, ForceMode.Impulse);
        }
    }

	// Update is called once per frame
	void Update ()
    {
        /***********************************************************/
        /*                 SHIT                                    */
        /***********************************************************/ 
        if (Input.GetKey(KeyCode.Escape))
            EditorApplication.isPlaying = false;


        gameObject.transform.Translate(Input.GetAxis("Horizontal") * MoveSpeedFactor,
                                       0f,
                                       Input.GetAxis("Vertical") * MoveSpeedFactor);

        gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                    height,
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
