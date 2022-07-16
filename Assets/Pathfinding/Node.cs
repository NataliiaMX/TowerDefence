using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //allows to serialize pure class
public class Node //no MonoBeheviour because I'm setting pure class here
{
    public Vector2Int coordinates;
    public bool isWalkable;
    public bool isExplored;
    public bool isPath;
    public Node connectedTo;

    public Node(Vector2Int coordinates, bool isWalkable)
    {
        this.coordinates = coordinates; //setting coordinates(paramater) to coordinates of this Node
        this.isWalkable = isWalkable;

    }
}
