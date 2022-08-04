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
        SceneManager.LoadScene(1);
    }

    public void ReloadGame ()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
}
