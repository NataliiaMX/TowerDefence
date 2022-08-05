using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    
    [SerializeField] int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }

    [SerializeField] TextMeshProUGUI displayBalance;
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] TextMeshProUGUI updatableText;
    [SerializeField] TextMeshProUGUI goldBalanceChange;

    public void Awake()
    {
        currentBalance = startingBalance;
        UpdateDisplay();
    }

    public void Deposit(int amount)
    {
        goldBalanceChange.text = "+" + amount.ToString();
        currentBalance += Mathf.Abs(amount);
        if (currentBalance > 200)
        {
            WinHandler();
        }
        UpdateDisplay();
        Invoke("ClearGoldChangeText", 3f);
    }

    public void Withdraw(int amount)
    {
        goldBalanceChange.text = "-" + amount.ToString();
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();

        if(currentBalance < 0)
        {
            GameOverHandler();
        }
        Invoke("ClearGoldChangeText", 3f);
    }

    void UpdateDisplay()
    {
        displayBalance.text = "Gold: " + currentBalance;
    }

    private void GameOverHandler ()
    {
        updatableText.text = "You lost!";
        gameOverCanvas.enabled = true;
        Time.timeScale = 0; // "stops" time
    }

    private void WinHandler()
    {
        updatableText.text = "You won";
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
    }

    private void ClearGoldChangeText ()
    {
        goldBalanceChange.text = " ";
    }
}
