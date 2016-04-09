using UnityEngine;
using System.Collections;
using System;

public class ContactIAControler : AbstractIAControler {

    public float fireRate = 0.5F;
    private float nextFire = 0.0F;

    // Use this for initialization
    protected override void Start ()
    {
        base.Start();
    }
	
	// Update is called once per frame
	protected override void Update ()
    {
        base.Update();
    }

    protected override void Attack()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            int angle = 20;
            Vector3 pushForce;
            do
            {
                pushForce = GetBallisticVelocity((target.position - transform.position).normalized * 7000f, angle);
                angle--;
            } while (float.IsNaN(pushForce.x) || float.IsNaN(pushForce.y) || float.IsNaN(pushForce.z));

            if (angle <= 0) return;
            target.gameObject.GetComponent<Rigidbody>().AddForce(pushForce, ForceMode.Impulse);
            target.GetComponent<BarbieLife>().decreaseLife(1);
        }
    }
}
