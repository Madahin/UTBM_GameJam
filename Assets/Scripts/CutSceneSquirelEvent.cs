using UnityEngine;
using System.Collections;

public class CutSceneSquirelEvent : MonoBehaviour {

    public Camera playerCamera;
    public Camera cutsceneCamera;

    public GameObject wall;
    public GameObject billboard;

    public Material badSquirellMaterial;
    public GameObject BadSquirell;

    public float speedWall = 1f;

    private bool canMoveWall = false;

	// Use this for initialization
	void Start () {
	
	}

    void Update()
    {
        if(canMoveWall)
        {
            wall.transform.position = Vector3.Lerp(wall.transform.position, new Vector3(wall.transform.position.x, 14.5f, wall.transform.position.z), Time.deltaTime * speedWall);
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
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GetComponent<QuickCutsceneController>().ActivateCutscene();
        }
    }
}
