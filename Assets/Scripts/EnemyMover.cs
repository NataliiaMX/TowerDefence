using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    List<Node> path = new List<Node>();
    [SerializeField] [Range(0f, 5f)] float speed = 1f;
    GridManager gridManager;
    PathFinder pathFinder;
    Enemy enemy;
    void OnEnable ()
    {
        ReturnToStart();
        RecalculatePath(true);
    }

    private void Awake() 
    {
        enemy = GetComponent<Enemy>();    
        gridManager = FindObjectOfType<GridManager>();
        pathFinder = FindObjectOfType<PathFinder>();
    }

    private void ReturnToStart()
    {
        transform.position = gridManager.GetPositionFromCoordinates(pathFinder.StartCoordinates);
    }

    private void RecalculatePath (bool resetPath) 
    {
        Vector2Int coordinates = new Vector2Int();

        if (resetPath)
        {
            coordinates = pathFinder.StartCoordinates;
        }
        else 
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
        }
        StopAllCoroutines();
        path.Clear();
        path = pathFinder.GetNewPath();
        StartCoroutine(FollowPath());
    }

    private IEnumerator FollowPath ()
    {
        for ( int i = 1; i < path.Count; i++)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = gridManager.GetPositionFromCoordinates(path[i].coordinates);
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
        enemy.TakeGold();
        gameObject.SetActive(false);
    }
}
