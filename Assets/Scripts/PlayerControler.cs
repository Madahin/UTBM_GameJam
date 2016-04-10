using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PlayerControler : MonoBehaviour
{

    //[Range(0.0f, 10.0f)]
    public float MaxSpeed;
    public float Speed;

    [Range(0.0f, 100.0f)]
    public float MouseSpeedFactor = 1.5f;

    public float ExpulseForce = 10.0f;

    public float height = 1.5f;

    public GameObject m_projectile;
    public float fireRate = 0.5F;
    private Camera mainCamera;
    private Rigidbody rigidBody;
    private float nextFire = 0.0F;
    public float thrust;

    void Awake()
    {
        GameManager.Instance.Player = this.gameObject;
    }

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        mainCamera = this.GetComponentInChildren<Camera>();
        rigidBody = this.GetComponent<Rigidbody>();
    }



    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //float yVelocity = rigidBody.velocity.y;

        Vector3 direction = mainCamera.transform.forward * vertical + mainCamera.transform.right * horizontal;
        direction.y = 0.0f;
        direction.Normalize();

        Vector3 speedVector = new Vector3(rigidBody.velocity.x, 0.0f, rigidBody.velocity.z);
        if (speedVector.magnitude <= MaxSpeed)
            rigidBody.AddForce(direction * Speed, ForceMode.Impulse);

        //rigidBody.velocity = direction * moveFactor + Vector3.up * yVelocity;
            



        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject projectile = GameObject.Instantiate(m_projectile, mainCamera.transform.position + mainCamera.transform.forward * 0.5f, mainCamera.transform.rotation) as GameObject;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.AddForce(mainCamera.transform.forward * ExpulseForce, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        /***********************************************************/
        /*               DICKBUTT  SHIT                            */
        /***********************************************************/
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.Escape))
            EditorApplication.isPlaying = false;
#endif

        /*gameObject.transform.Translate(Input.GetAxis("Horizontal") * MoveSpeedFactor,
                                       0f,
                                       Input.GetAxis("Vertical") * MoveSpeedFactor);

        gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                    height,
                                                    gameObject.transform.position.z);*/

        mainCamera.transform.Rotate(-Input.GetAxis("Mouse Y") * MouseSpeedFactor * Time.deltaTime, 0f, 0f);
        mainCamera.transform.Rotate(0f, Input.GetAxis("Mouse X") * MouseSpeedFactor * Time.deltaTime, 0f);

        float gimbalLock = mainCamera.transform.rotation.eulerAngles.x;

        if (gimbalLock >= 269 && gimbalLock < 275)
        {
            gimbalLock = 275f;
        }

        if (gimbalLock >= 87 && gimbalLock < 91)
        {
            gimbalLock = 88f;
        }

        mainCamera.transform.rotation = Quaternion.Euler(gimbalLock,
                                                         mainCamera.transform.rotation.eulerAngles.y,
                                                         0f);




    }
}
