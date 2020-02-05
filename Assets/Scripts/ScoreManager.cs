using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameObject[] lives;
    [SerializeField] Text score;

    private int scoreInt=0;
    private int currentLives = 3;

    // Start is called before the first frame update
    void Start()
    {
        scoreInt = 0;
        currentLives = 3;
        score.text = "jandumola";// scoreInt.ToString("000000");
        //score.text = scoreInt.ToString();
    }

    public void AddScore(int value){
        scoreInt+=value;
        score.text = scoreInt.ToString("000000");
    }

    public void LoseLife()
    {
        currentLives--;
        if (currentLives >= 0)
        {
            lives[currentLives].SetActive(false);
        }
    }
    
}
