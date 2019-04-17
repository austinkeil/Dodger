using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public Text score;
    public InputField playerName;
    public GameObject playerNamePanel;


    // Start is called before the first frame update
    public void IncreaseScore()
    {
        score.text = (Convert.ToInt32(score.text) + 1).ToString();
        Debug.Log("Score Increased!");

    }

    public void SaveScore()
    {

        int scoreNum = Convert.ToInt32(score.text);
        
        // playerNamePanel.SetActive(false);
        

        int index = 10;

        while (scoreNum > Convert.ToInt32(PlayerPrefs.GetString("Score" + index.ToString())) && index > 0)
        {

            PlayerPrefs.SetString("Score" + (index + 1).ToString(),
                PlayerPrefs.GetString("Score" + (index).ToString()));

            PlayerPrefs.SetString("Name" + (index + 1).ToString(), PlayerPrefs.GetString("Name" + (index).ToString()));
            index--;
        }

        Debug.Log("score almost set");
        
        PlayerPrefs.SetString("Score" + (index + 1).ToString(), scoreNum.ToString());
        PlayerPrefs.SetString("Name" + (index + 1).ToString(), playerName.text);

        Debug.Log("Set Score");


    }

    public void CheckScore()
    {
    int scoreNum = Convert.ToInt32(score.text);
    Debug.Log("entering score saver");

    PlayerHealth playerHealth =
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        
        if (Convert.ToInt32(PlayerPrefs.GetString("Score10")) > scoreNum)
    {

            
        return;
    }
    Debug.Log("Score in top 10");
    playerNamePanel.SetActive(true);

    playerHealth.deathText.text = "NEW HIGHSCORE\nMOTHERFUCKER";
        
    }

}
