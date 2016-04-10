using UnityEngine;
using System.Collections;
using System;

public class BulletCollision : MonoBehaviour {

    public ParticleSystem m_particule;
    // Use this for initialization

    public float smoothing = 1f;
    public Transform target;

    void Start () {
        m_particule.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter(Collision col)
    {
        m_particule.gameObject.SetActive(true);
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;
        StartCoroutine(MyCoroutine(gameObject.transform, gameObject));

        if (col.gameObject.tag == "Player")
        {
            Vector3 direction = this.transform.position - col.gameObject.transform.position;
            direction.Normalize();

            col.gameObject.GetComponent<Rigidbody>().AddForce(direction * 1000.0f, ForceMode.Impulse);

            /*int angle = 25;
            Vector3 pushForce;
            do
            {
                pushForce = BallisticVel(target, angle);
                angle--;
            } while (float.IsNaN(pushForce.x) || float.IsNaN(pushForce.y) || float.IsNaN(pushForce.z));

            if (angle <= 0) return;
            target.gameObject.GetComponent<Rigidbody>().AddForce(pushForce, ForceMode.Impulse);
            target.GetComponent<BarbieLife>().decreaseLife(1);*/
        }
    }

    private Vector3 BallisticVel( Transform target, float angle)  {
        var dir = target.position - transform.position;
        // get target direction 
        var h = dir.y;
        // get height difference 
        dir.y = 0; 
        // retain only the horizontal direction 
        var dist = dir.magnitude ;
        // get horizontal distance 
        var a = angle * Mathf.Deg2Rad;
        // convert angle to radians 
        dir.y = dist * Mathf.Tan(a);
        // set dir to the elevation angle 
        dist += h / Mathf.Tan(a); 
        // correct for small height differences 
        // calculate the velocity magnitude 
        var vel = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return vel * dir.normalized; 
    }

    IEnumerator MyCoroutine(Transform target, GameObject objet)
    {

        yield return new WaitForSeconds(3f);

        DestroyImmediate(objet);
    }
    
}
