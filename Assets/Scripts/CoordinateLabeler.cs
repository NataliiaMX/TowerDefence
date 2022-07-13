using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
    {
    [SerializeField] Color defaultColor = Color.black;
    [SerializeField] Color blockedColor = Color.gray;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    WayPoint waypoint;
    
    private void Awake() 
    {
        DisplayCoordinates();
        waypoint = GetComponentInParent<WayPoint>();
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
    }
    private void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
        SetLabelColor();
        ToggleLabels();
    }

    private void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    private void SetLabelColor()
    {
       
        if (waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else 
        {
            label.color = blockedColor;
        }
    }

    private void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / 
        UnityEditor.EditorSnapSettings.move.x); //bc changed snap movement settings
        Debug.Log(coordinates.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / 
        UnityEditor.EditorSnapSettings.move.z); //z because I'm working in a,z axis like with x,y axes 
        Debug.Log(coordinates.y);
        label = GetComponent<TextMeshPro>();

        label.text = coordinates.x + "," + coordinates.y;
    }
    private void UpdateObjectName()
    {
        transform.parent.name = "Tile" + coordinates.ToString();
    } 
}
