using UnityEngine;
using System.Collections;
using UnityEngine.Assertions;

public abstract class AbstractIAControler : MonoBehaviour {
  
    public float maxDistance;
    public float minDistance;
    
    public float attackDistance;

    protected float distanceBetweenTarget = float.MaxValue;

    protected Transform target;

    private NavMeshPath path;
    private float elapsed = 0.0f;

    private bool hasSawPlayer = false;

    protected NavMeshAgent agent;

    // Use this for initialization
    protected virtual void Start ()
    {
        target = GameManager.Instance.Player.transform;
        path = new NavMeshPath();
        elapsed = 0.0f;

        agent = GetComponent<NavMeshAgent>();

        SanitizeAttribute();
    }
	
	// Update is called once per frame
	protected virtual void Update ()
    {
        distanceBetweenTarget = Vector3.Distance(transform.position, target.position);
        
        if (distanceBetweenTarget > minDistance && distanceBetweenTarget < maxDistance)
        {
            agent.Resume();

            RaycastHit hit;
            bool hasHit = Physics.Linecast(transform.position, target.position, out hit);

            if (!hasHit || hit.transform.gameObject.name == "Barbie")
            {
                hasSawPlayer = true;
            }

            if (hasSawPlayer)
            {
                UpdateNavMesh();
            }
        }
        else
        {
            agent.Stop();
        }

        if(distanceBetweenTarget < attackDistance)
        {
            Attack();
        }
    }

    protected virtual void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
        Debug.Log("aa");
    }

    protected virtual void SanitizeAttribute()
    {
        Assert.IsTrue(minDistance < maxDistance);
        Assert.IsTrue(attackDistance >= minDistance && attackDistance < maxDistance);
    }

    private void UpdateNavMesh()
    {
        // Update the way to the goal every second.
        elapsed += Time.deltaTime;
        if (elapsed > 0.1f)
        {
            elapsed -= 1.0f;
            NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path);
            agent.SetPath(path);
        }
        for (int i = 0; i < path.corners.Length - 1; i++)
            Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
    }

    protected Vector3 GetBallisticVelocity(Vector3 targetVec, float angle)
    {
        Vector3 dir = targetVec - transform.position;

        float h = dir.y;

        dir.y = 0;

        float dist = dir.magnitude;

        float a = angle * Mathf.Deg2Rad;

        dir.y = dist * Mathf.Tan(a);

        dist += h / Mathf.Tan(a);

        float vel = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));

        return vel * dir.normalized;
    }

    protected abstract void Attack();
}
