using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public Text score;
    
    // Start is called before the first frame update
    public void IncreaseScore()
    {
        score.text = (Convert.ToInt32(score.text) + 1).ToString();
        Debug.Log("Score Increased!");

    }
}
