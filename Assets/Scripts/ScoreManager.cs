using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score;

    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "SCORE: " + score;
    }
    public void UpdateScore(int increment)
    {
    	 score += increment;
         scoreText.text = "Score: " + score;
    }
}
