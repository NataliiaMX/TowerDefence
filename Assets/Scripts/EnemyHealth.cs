using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))] 
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHP = 5;
    [SerializeField] int currentHP = 0;
    [Tooltip("Adds amount to maxHP every time enemy dies")]
    [SerializeField] int difficultyRamp = 2;
    Enemy enemy;

    void OnEnable()
    {
        currentHP = maxHP;     
    }

    private void Start() 
    {
        enemy = GetComponent<Enemy>();    
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
            maxHP += difficultyRamp;
            //Debug.Log(maxHP);
            gameObject.SetActive(false);
            enemy.RewardGold();
        }
    }

}
