using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;

    public float updateRate = 2f;

    public float health = 20f;

    private Seeker seeker;
    private Rigidbody2D rb;

    public Path path;

    public float speed = 300f;
    public ForceMode2D fMode;


    [HideInInspector]
    public bool pathIsEnded = false;

    public float nextWaypointDistance = 3;

    private int currentWaypoint = 0;
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if (target == null) {
            Debug.LogError("bad times");
            return;
        }

        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath ());
    }

    IEnumerator UpdatePath () {
        if (target == null) {
            Debug.Log("Bad");
        }
        seeker.StartPath(transform.position, target.position, OnPathComplete);
        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());

    }

    public void OnPathComplete(Path p) {
        if (!p.error) {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (path == null) { return; }

        if (currentWaypoint >= path.vectorPath.Count) {
            if (pathIsEnded) 
                return;
            Debug.Log("end of path reached");
            pathIsEnded = true;
            return;
        }
        pathIsEnded = false;

        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;

        rb.AddForce(dir, fMode);

        if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance) {
            currentWaypoint++;
            return;
        }

        if (health == 0) {
            Destroy(gameObject);
        }
    }

    public void loseHealth() {
        health -= 10f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") { 
            Player player = collision.gameObject.GetComponent<Player>();
            player.current_02 -= 10;
        }
    }


}
