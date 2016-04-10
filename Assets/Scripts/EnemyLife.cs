using UnityEngine;
using System.Collections;

public class EnemyLife : MonoBehaviour {

    public int life = 3;

    private bool isDead = false;

    private GameObject particleObject;

    void Start()
    {
        particleObject = GetComponent<ParticleSystem>().gameObject;
        particleObject.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
	    if(isDead)
        {
            StartCoroutine(DieCoroutine());
        }
	}

    public void DecreaseLife()
    {
        if (!isDead)
        {
            life--;
            isDead = life == 0;
        }
    }

    IEnumerator DieCoroutine()
    {
        GetComponent<AbstractIAControler>().Stop();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;

        particleObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        yield return null;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "BarbieProjectile")
        {
            DecreaseLife();
        }
    }
}
