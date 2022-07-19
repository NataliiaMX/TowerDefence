using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    GridManager gridManager;
    Vector2Int coordinates = new Vector2Int();
    [SerializeField] Tower tower;
    [SerializeField] bool isPlaceable = true;
    public bool IsPlaceable { get { return isPlaceable; }} //property of variable isPlacceable

    private void Awake() 
    {
        gridManager = FindObjectOfType<GridManager>();    
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
        if (isPlaceable)
        {
            bool isPlaced = tower.CreateTower(tower, transform.position);
            isPlaceable = !isPlaced;
        }
        
    }
}
