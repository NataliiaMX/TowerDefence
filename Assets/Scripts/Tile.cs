using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    GridManager gridManager;
    Vector2Int coordinates = new Vector2Int();
    PathFinder pathFinder;

    [SerializeField] Tower tower;
    [SerializeField] bool isPlaceable = true;
    public bool IsPlaceable { get { return isPlaceable; }} //property of variable isPlacceable

    private void Awake() 
    {
        gridManager = FindObjectOfType<GridManager>();    
        pathFinder = FindObjectOfType<PathFinder>();
    }

    private void Start() 
    {
        if (gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if (!isPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }
    private void OnMouseDown() //on click
    {
        if (gridManager.GetNode(coordinates).isWalkable && !pathFinder.WillBlockPath(coordinates))
        {
            bool isSuccessful = tower.CreateTower(tower, transform.position);

            if (isSuccessful)
            {
               gridManager.BlockNode(coordinates);  
               pathFinder.NotifyReceivers();
            }
        }
    }
}
