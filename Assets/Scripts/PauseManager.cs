using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField] GameObject canvas;


    public void Continue(){
        canvas.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    public void Quit(){
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }


    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (!isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            ActivatePause();
        }else if(isPaused && Input.GetKeyDown(KeyCode.Escape)){
            Continue();
        }
    }

    void ActivatePause(){
        isPaused = true;

        canvas.SetActive(true);

        Time.timeScale = 0;
    }
}
