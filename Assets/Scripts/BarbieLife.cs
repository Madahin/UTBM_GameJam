using UnityEngine;
using System.Collections;

public class BarbieLife : MonoBehaviour {
    public int life;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void decreaseLife(int degats)
    {
        // check si barbie die
        life = life - degats;

        SoundOnDommage sod = GetComponent<SoundOnDommage>();

        if(sod != null)
        {
            sod.Play();
        }

        if(life == 0)
        {
            GameManager.Instance.LoadLevel("GameOver");
        }
    }

    void OnCollisionEnter(Collision col)
    {
       if ( col.gameObject.tag == "EnemieProjectile")
        {
            // dégat a changer
            this.decreaseLife(1);
            
        }
    }
}
