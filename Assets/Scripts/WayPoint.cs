using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable = true;
    private void OnMouseDown() //on click
    {
        if (isPlaceable)
        {
            Debug.Log(transform.name);
        }
        
    }
}
