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

    public void SaveScore()
    {
        int scoreNum = Convert.ToInt32(score.text);

        int index = 10;

        while (scoreNum > Convert.ToInt32(PlayerPrefs.GetString("Score" + index.ToString())) && index > 0)
        {
            
            PlayerPrefs.SetString("Score" + (index+1).ToString(), PlayerPrefs.GetString("Score" + (index).ToString()));
            index--;
        }

        PlayerPrefs.SetString("Score" + (index + 1).ToString(), scoreNum.ToString());



    }
}
