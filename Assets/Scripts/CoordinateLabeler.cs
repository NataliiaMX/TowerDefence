using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    private void Awake() 
    {
        DisplayCoordinates();
    }
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
    }

    private void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / 
        UnityEditor.EditorSnapSettings.move.x); //bc changed snap movement settings 
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / 
        UnityEditor.EditorSnapSettings.move.z); //z because I'm working in a,z axis like with x,y axes 
        label = GetComponent<TextMeshPro>();

        label.text = coordinates.x + "," + coordinates.y;
    }
    private void UpdateObjectName()
    {
        transform.parent.name = "Tile" + coordinates.ToString();
    } 
}
