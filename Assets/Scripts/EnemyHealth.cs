using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHP = 5;
    [SerializeField] int currentHP = 0;

    void OnEnable()
    {
        currentHP = maxHP;     
    }

    void OnParticleCollision(GameObject other) 
    {
        ProcessHit();
    }

    void ProcessHit() 
    {
        currentHP--;

        if(currentHP <= 0)
        {
            gameObject.SetActive(false);
        }
    }

}
