using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    void Start()
    {
        PrintWaypointName();
    }

    private void PrintWaypointName ()
    {
        foreach (WayPoint waypoint in path)
        {
            Debug.Log(waypoint.name);
        }
    }
}
