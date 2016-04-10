using UnityEngine;
using System.Collections;

public class EnemyLife : MonoBehaviour {

    public int life = 3;

    private bool isDead = false;

    public GameObject particleObject;

    void Start()
    {
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
        GetComponent<CapsuleCollider>().enabled = false;

        particleObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        Debug.Log("dead");
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
