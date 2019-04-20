using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public Text score;
    // where the player enters their name
    public InputField playerName;
    // the panel that holds the input field
    public GameObject playerNamePanel;


    // Start is called before the first frame update
    public void IncreaseScore()
    {
        score.text = (Convert.ToInt32(score.text) + 1).ToString();
        Debug.Log("Score Increased!");

    }

    // sorts and stores new high scores
    public void SaveScore()
    {

        int scoreNum = Convert.ToInt32(score.text);
        
        // playerNamePanel.SetActive(false);
        

        int index = 10;

        // uses insertion sort
        while (scoreNum > Convert.ToInt32(PlayerPrefs.GetString("Score" + index.ToString())) && index > 0)
        {

            PlayerPrefs.SetString("Score" + (index + 1).ToString(),
                PlayerPrefs.GetString("Score" + (index).ToString()));

            PlayerPrefs.SetString("Name" + (index + 1).ToString(), PlayerPrefs.GetString("Name" + (index).ToString()));
            index--;
        }

        Debug.Log("score almost set");
        // saves the score and name in preferences
        PlayerPrefs.SetString("Score" + (index + 1).ToString(), scoreNum.ToString());
        PlayerPrefs.SetString("Name" + (index + 1).ToString(), playerName.text);

        Debug.Log("Set Score");


    }

    // checks whether a new high score what achieved
    public void CheckScore()
    {
        
    int scoreNum = Convert.ToInt32(score.text);
    Debug.Log("entering score saver");

    // gets player health object to change death text

        
    if (Convert.ToInt32(PlayerPrefs.GetString("Score10")) > scoreNum)return;
    
    Debug.Log("Score in top 10");
    PlayerHealth playerHealth =
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    
    // sets the insertian field to active
    playerNamePanel.SetActive(true);

    // displays a different message
    playerHealth.deathText.text = "NEW HIGHSCORE\nMOTHERFUCKER";
        
    }

}
