using UnityEngine;
using System.Collections;

public class DistanceIAControler : AbstractIAControler {

    public GameObject m_projectile;
    public float fireRate = 0.5F;
    private float nextFire = 0.0F;

    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void Attack()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            Vector3 normalizedDirection = (target.position - transform.position).normalized;
            GameObject projectile = GameObject.Instantiate(m_projectile, transform.position + normalizedDirection * 2f, transform.rotation) as GameObject;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            Vector3 ballisticVelocity = GetBallisticVelocity(target.position, RandomDevice.NextInt(15, 60));

            rb.AddForce(ballisticVelocity, ForceMode.Impulse);

            SoundOnAttack soa = GetComponent<SoundOnAttack>();

            if(soa != null)
            {
                soa.Play();
            }
        }
    }

    
}
