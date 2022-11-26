using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingPath : MonoBehaviour
{
    [Header("Waypoints")]
    [SerializeField] private Transform[] waypointList;
    [SerializeField] private int currentWaypoint = 0;

    private ChasingPlayer chasingPlayer;

    private NavMeshAgent agent;
    private Transform nextWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        chasingPlayer = GetComponent<ChasingPlayer>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!chasingPlayer.FindPlayer() && !chasingPlayer.playerCaught)
        {
            if (nextWaypoint == null)
            {
                nextWaypoint = waypointList[currentWaypoint];
            }
            Patrol();
        }
    }
    private void Patrol()
    {
        //Moving towards the destination
        agent.destination = waypointList[currentWaypoint].transform.position;
        
        //When the agent reaches the waypoint it will move on to the next
        if (transform.position.x == waypointList[currentWaypoint].transform.position.x &&
           transform.position.z == waypointList[currentWaypoint].transform.position.z)
        {

                if (currentWaypoint < waypointList.Length - 1)
                {
                    currentWaypoint++;
                    nextWaypoint = waypointList[currentWaypoint];
                }
                else
                {
                    currentWaypoint = 0;
                    nextWaypoint = null;
                }
        }
    }
}
