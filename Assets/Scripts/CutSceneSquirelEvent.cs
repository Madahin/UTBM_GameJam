using UnityEngine;
using System.Collections;

public class CutSceneSquirelEvent : MonoBehaviour {

    public Camera playerCamera;
    public Camera cutsceneCamera;

    public GameObject wall;
    public GameObject billboard;

    public Material badSquirellMaterial;
    public GameObject BadSquirell;

    private GameObject boss;

    public GameObject door;

    public float speedWall = 1f;

    private bool canMoveWall = false;
    private bool battleBegin = false;

	// Use this for initialization
	void Start () {
	
	}

    void Update()
    {
        if(canMoveWall)
        {
            wall.transform.position = Vector3.Lerp(wall.transform.position, new Vector3(wall.transform.position.x, 14.5f, wall.transform.position.z), Time.deltaTime * speedWall);
        }

        if(battleBegin && boss == null)
        {
            door.SetActive(true);
        }
    }

    void DisableCamera()
    {
        playerCamera.enabled = false;
    }

    void MoveWall()
    {
        canMoveWall = true;
    }

    void SquirelToEvil()
    {
        billboard.GetComponent<MeshRenderer>().material = badSquirellMaterial;
    }

    void Begin()
    {
        GetComponent<BoxCollider>().enabled = false;

        GameObject squirell = GameObject.Instantiate(BadSquirell, billboard.transform.position, billboard.transform.rotation) as GameObject;

        //squirell.transform.position = billboard.transform.position;
        //squirell.transform.rotation = billboard.transform.rotation;
        squirell.transform.localScale = billboard.transform.localScale;

        Destroy(billboard);

        playerCamera.enabled = true;
        cutsceneCamera.enabled = false;

        boss = squirell;
        battleBegin = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GetComponent<QuickCutsceneController>().ActivateCutscene();
        }
    }
}
