using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    public int CurrentBalance { get {return currentBalance;} }
    
    private void Awake() 
    {
        currentBalance = startingBalance;
    }
    public void Deposit (int amount)
    {
        currentBalance += Mathf.Abs(amount); //abs to remove possible negative sign of amount
    }

    public void Withdraw (int amount)
    {
        currentBalance -= Mathf.Abs(amount);

        if (currentBalance <= 0)
        {
            Debug.Log("lost");
            ReloadScene();
        }
    }

    private void ReloadScene ()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
