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
        if (!Physics.Linecast(transform.position, target.position) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            Vector3 normalizedDirection = (target.position - transform.position).normalized;
            GameObject projectile = GameObject.Instantiate(m_projectile, transform.position + normalizedDirection * 2f, transform.rotation) as GameObject;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();

            Vector3 ballisticVelocity = GetBallisticVelocity(target, RandomDevice.NextInt(15, 60));

            rb.AddForce(ballisticVelocity, ForceMode.Impulse);
        }
    }

    private Vector3 GetBallisticVelocity(Transform targetVec, float angle)
    {
        Vector3 dir = target.position - transform.position;

        float h = dir.y;

        dir.y = 0;

        float dist = dir.magnitude;

        float a = angle * Mathf.Deg2Rad;

        dir.y = dist * Mathf.Tan(a);

        dist += h / Mathf.Tan(a);

        float vel = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));

        return vel * dir.normalized;
    }
}
