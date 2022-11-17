using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TeacherMovement : MonoBehaviour
{    
    int ind = 0;
    public Transform[] target;
    public float speed = 200f;
    public float nextWayPointDist = 3f;
    
    Path path;
    int currWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {
        // for(int i=0; i<target.Length; i++)
        //     Debug.Log(target[i]+" \n ");
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, 0.1f);
    }

    void UpdatePath()
    {
        if(seeker.IsDone())
            seeker.StartPath(rb.position, target[ind].position, OnPathComplete); 
    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currWaypoint = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D CollisionInfo)
    {
        
        if(CollisionInfo.gameObject.tag == "Player")
        {
            Debug.Log("Ahh.. Ahh... AAAAAhhhhhh!!!");
        }
    }


    void FixedUpdate()
    {
        if(path == null)
            return;

        if(currWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            ind = (ind+1)%target.Length;
            UpdatePath();
            // Debug.Log(ind);
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        if(currWaypoint==0)
            currWaypoint++;
        Vector2 direction = ((Vector2)path.vectorPath[currWaypoint] - rb.position).normalized;
        Vector2 force = direction*speed*Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currWaypoint]);

        if(distance < nextWayPointDist)
        {
            currWaypoint++;
        }

    }
}
