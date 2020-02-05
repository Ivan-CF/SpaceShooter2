using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PulsaPlay(){
        Debug.LogError("He pulsado Play");

        SceneManager.LoadScene("Game");
    }

    public void PulsaExit(){
        Application.Quit();
    }
}
