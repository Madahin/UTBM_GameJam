using UnityEngine;
using System.Collections;

public class BarbieLife : MonoBehaviour {
    public int life;

    private CapsuleCollider _colider;
    private PlayerControler _controller;
    private Rigidbody _rigidBody;
	// Use this for initialization
	void Start () {
        _colider = GetComponent<CapsuleCollider>();
        _controller = GetComponent<PlayerControler>();
        _rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void decreaseLife(int degats)
    {
        

        // check si barbie die
        life = life - degats;
        if(life == -1)
        {
            SoundOnDie sod = GetComponent<SoundOnDie>();
            if (sod != null)
            {
                GetComponent<AudioClipRandomizer>().StopAudio();
                GetComponent<AudioClipRandomizer>().enabled = false;
                sod.Play();
            }

            Destroy(GameManager.Instance.ambientMusic);

            _controller.enabled = false;
            _rigidBody.detectCollisions = false;
            _colider.enabled = false;
            
            StartCoroutine(LookAtDeath());
        }
        else
        {
            SoundOnDommage sod = GetComponent<SoundOnDommage>();

            if (sod != null)
            {
                GetComponent<AudioClipRandomizer>().StopAudio();
                sod.Play();
            }
        }
    }

    private IEnumerator LookAtDeath()
    {
        Quaternion initialRot = this.transform.rotation;
        Quaternion finalRot = Quaternion.LookRotation(this.transform.up * 1.0f + this.transform.forward * 0.0001f);
        float _timer = 0.0f;
        float _reachTime = 3.0f;

        GameManager.Instance.LoadLevel("Menu");
        while (_timer < _reachTime)
        {
            _timer += Time.deltaTime;
            this.transform.rotation = Quaternion.Slerp(initialRot, finalRot, _timer / _reachTime);
            yield return new WaitForEndOfFrame();
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "EnemieProjectile")
        {
            // dégat a changer
            this.decreaseLife(1);

        }
    }
}
