using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score; 

    // Start is called before the first frame update
    void Start()
    {
        score = 0; 
        AddScore(0);
        scoreText.text = "Score: " + score;
    }

     public void AddScore(int earnedScore)
    {
        score = score + earnedScore;
        scoreText.text = "Score: " + score;
    }
}
