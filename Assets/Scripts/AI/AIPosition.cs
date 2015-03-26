using UnityEngine;
using System.Collections;

public class AIPosition : MonoBehaviour 
{
	//Variables for the POSITION of AI characters.
	public GameObject npc;
	
	public GameObject waypoint1;
	public GameObject waypoint2;
	public GameObject waypoint3;
	public GameObject waypoint4;

	public Transform lookAtTarget;

	private bool onPoint1;
	private bool onPoint2;
	private bool onPoint3;
	private bool onPoint4;

	private bool path1;
	private bool path2;
	private bool path3;
	private bool path4;

	//Variables for the PATHFINDING of AI characters.
	public GameObject lastWaypoint;
	public GameObject nextWaypoint;
	
	public Vector3 npcPosition;
	public Vector3 lastWaypointPosition;
	public Vector3 nextWaypointPosition;
	
	private bool travelPath1;
	private bool travelPath2;
	private bool travelPath3;
	private bool travelPath4;
	
	public bool npcIsMoving;
	public bool npcIsReadyToMove;
	public bool npcStop = false;
	
	//public float step;
	public float speed;

	void Awake ()
	{
		npc.transform.position = waypoint1.transform.position;
	}

	void FixedUpdate ()
	{
		npcPosition = new Vector3 (npc.transform.position.x, npc.transform.position.y, npc.transform.position.z);

		npcIsMoving = true;

		if (npc.transform.position == waypoint1.transform.position)
		{
			//determines that the npc is on their first waypoint
			onPoint1 = true;

			//tells AIPathfinding that the npc has stopped moving/ is at a waypoint
			npcIsMoving = false;

			//turns the npc towards their next waypoint
			lookAtTarget = waypoint2.transform;
			npc.transform.LookAt(lookAtTarget);

			//tells AIPathfinding that the npc is done turning towards the next waypoint
			npcIsReadyToMove = true;

			//tells AIPathfinding what the last and next waypoints are
			lastWaypoint = waypoint1;
			nextWaypoint = waypoint2;
		}
		else if (npc.transform.position == waypoint2.transform.position)
		{
			onPoint2 = true;

			npcIsMoving = false;

			lookAtTarget = waypoint3.transform;
			npc.transform.LookAt (lookAtTarget);

			npcIsReadyToMove = true;

			lastWaypoint = waypoint2;
			nextWaypoint = waypoint3;
		}
		else if (npc.transform.position == waypoint3.transform.position)
		{
			onPoint3 = true;

			npcIsMoving = false;

			lookAtTarget = waypoint4.transform;
			npc.transform.LookAt (lookAtTarget);

			npcIsReadyToMove = true;
			
			lastWaypoint = waypoint3;
			nextWaypoint = waypoint4;
		} 
		else if (npc.transform.position == waypoint4.transform.position)
		{
			onPoint4 = true;

			npcIsMoving = false;

			lookAtTarget = waypoint1.transform;
			npc.transform.LookAt (lookAtTarget);

			npcIsReadyToMove = true;
			
			lastWaypoint = waypoint4;
			nextWaypoint = waypoint1;
		}




		if (npcIsMoving == false && npcIsReadyToMove == true);
		{
			//gets the last waypoint position from the AIPosition script
			lastWaypointPosition = new Vector3 (lastWaypoint.transform.position.x, lastWaypoint.transform.position.y, lastWaypoint.transform.position.z);
			//gets the next waypoint position from the AIPosition script
			nextWaypointPosition = new Vector3 (nextWaypoint.transform.position.x, nextWaypoint.transform.position.y, nextWaypoint.transform.position.z);
			
			npc.transform.position = Vector3.MoveTowards (lastWaypointPosition, nextWaypointPosition, speed);
		}
		
		if(npcIsMoving == true && npcStop == false)
		{
			npc.transform.position = Vector3.MoveTowards (npcPosition, nextWaypointPosition, speed);
		}
	}
}
