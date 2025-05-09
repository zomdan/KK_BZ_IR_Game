using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    public float speed = 5f; // Train speed
    public Transform[] waypoints; // Array of waypoints

    private int currentWaypointIndex = 0; // Current waypoint index

    private void Update()
    {
        if (waypoints.Length == 0)
            return;

        Transform targetWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= waypoints.Length)
            {
                // Reset to the first waypoint to loop again
                currentWaypointIndex = 0;

                // Optional: Reset position to the first waypoint exactly (optional smoothness improvement)
                transform.position = waypoints[0].position;
            }
        }
    }
}
