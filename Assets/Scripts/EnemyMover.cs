using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<WayPoint> path = new List<WayPoint>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;
    void Start()
    {
        StartCoroutine(FollowPath());
        
    }

    private IEnumerator FollowPath ()
    {
        foreach (WayPoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition); //to rotate enemy to face correcr way

            while(travelPercent < 1f) //while not on end position
            {
                travelPercent += Time.deltaTime * speed; //adds number every frame till enemy reaches position (travelPercent = 1)
                transform.position = Vector3.Lerp(startPosition,endPosition, travelPercent); //results in smoother moving
                yield return new WaitForEndOfFrame();
            }
     

            //this method allows to use coroutine and iterate throuth path with delay without Invoke
        }
    }
}
