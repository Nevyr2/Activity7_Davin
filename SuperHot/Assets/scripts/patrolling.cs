using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class patrolling : MonoBehaviour {

    public Transform[] waypoint;
    public GameObject NPC;
    NavMeshAgent agent;
    const int epsilon = 2;
    float idle = 0;
    float time_idle;
    bool arrived = false;
    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoint[4].position);
        idle = Random.Range(0, 5f);
    }
	
	// Update is called once per frame
	void Update () {
        if ((transform.position - waypoint[Random.Range(0, waypoint.Length)].position).magnitude < epsilon)
        {
            arrived = true;
        }
        if (arrived)
        {
            idle += Time.deltaTime;
            NPC.GetComponent<NPCMovement>().idle = true;
            if (idle > time_idle)
            {
                agent.SetDestination(waypoint[Random.Range(0, waypoint.Length)].position);
                idle = 0;
                time_idle = Random.Range(0, 5f);
                NPC.GetComponent<NPCMovement>().idle = false;
                arrived = false;
            }
        }

        
    }

}
