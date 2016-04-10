using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(0.0f, 10.0f * Time.deltaTime, 0.0f);
	}

    public void StartGame()
    {
        GameManager.Instance.LoadLevel("Level1");
    }
     public void RageQuit()
    {
        Application.Quit();
    }

}
