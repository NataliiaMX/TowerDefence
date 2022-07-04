using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform wearpon;
    [SerializeField] Transform target;
    private void Start() 
    {
        target = FindObjectOfType<EnemyMover>().transform;
    }
    private void Update() 
    {
        AimWearpon();
    }

    private void AimWearpon()
    {
        wearpon.LookAt(target);
    }
}
