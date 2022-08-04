using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;

    public void Start ()
    {
       gameOverCanvas.enabled = false; 
    }
    public void StartGame ()
    {
        SceneManager.LoadScene("Game");
    }

    public void ReloadGame ()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);

    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
