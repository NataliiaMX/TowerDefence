using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
   
    [SerializeField] GameObject tower;
    [SerializeField] bool isPlaceable = true;
    private void OnMouseDown() //on click
    {
        if (isPlaceable)
        {
            Instantiate(tower, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
        
    }
}
