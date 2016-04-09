using UnityEngine;
using System.Collections;

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
    }
    
    IEnumerator MyCoroutine(Transform target, GameObject objet)
    {

        yield return new WaitForSeconds(3f);

        DestroyImmediate(objet);
    }
    
}
