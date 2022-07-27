using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform wearpon;
    [SerializeField] float towerRange = 1f;
    [SerializeField] ParticleSystem projectileParticle;
    Transform target;
    
    private void Update() 
    {
        FindClosestTarget();
        AimWearpon();
    }

    private void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        target = closestTarget;
    }

    private void AimWearpon()
    {
        if (target != null)
        {
            float targetDistance = Vector3.Distance(transform.position, target.transform.position);
        wearpon.LookAt(target);

        if(targetDistance < towerRange)
        {
            Attack(true);
        }
        else 
        {
            Attack(false);
        }
        }
    }

    private void Attack(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}
