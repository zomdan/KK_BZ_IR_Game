using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMovement : MonoBehaviour
{
    public float speed = 5f; // Train speed
    public Transform[] waypoints; // Array of waypoints

    private int currentWaypointIndex = 0; // Current waypoint index
    private int direction = 1; // Movement direction: 1 - forward, -1 - backward

    private void Update()
    {
        if (waypoints.Length == 0)
            return;

        // Select the target waypoint
        Transform targetWaypoint = waypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        // If the train reaches the target point
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            // Change direction if reached the first or last waypoint
            if (currentWaypointIndex == 0)
            {
                direction = 1;
            }
            else if (currentWaypointIndex == waypoints.Length - 1)
            {
                direction = -1;
            }
            // Update the index
            currentWaypointIndex += direction;
        }
    }
}
