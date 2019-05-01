using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class ScoreScript : MonoBehaviour
{

    public Text score;
    // where the player enters their name
    public InputField playerName;
    // the panel that holds the input field
    public GameObject playerNamePanel;

    public GameObject projectileArea;

    private ProjectileGeneration projectileGeneration;
    


    void Start()
    {
        projectileGeneration = projectileArea.GetComponent<ProjectileGeneration>();


    }

    private string[] devNames = {"Selah", "Austin", "Joseph", "Trevor"};


    // Start is called before the first frame update
    public void IncreaseScore()
    {

        int scoreNum = Convert.ToInt32(score.text) + 1;
        score.text = scoreNum.ToString();
        Debug.Log("Score Increased!");

        if (scoreNum % 20 == 0)
        {
            projectileGeneration.IncreaseDifficulty();




        }

    }

    // sorts and stores new high scores
    public void SaveScore()
    {

        int scoreNum = Convert.ToInt32(score.text);
        
        // playerNamePanel.SetActive(false);

        String difficulty = PlayerPrefs.GetInt("Difficulty").ToString();
        
        int index = 10;

        // uses insertion sort
        while (scoreNum > Convert.ToInt32(PlayerPrefs.GetString(difficulty + "Score" + index.ToString())) && index > 0)
        {

            PlayerPrefs.SetString(difficulty + "Score" + (index + 1).ToString(),
                PlayerPrefs.GetString(difficulty + "Score" + (index).ToString()));

            PlayerPrefs.SetString(difficulty + "Name" + (index + 1).ToString(), PlayerPrefs.GetString(difficulty + "Name" + (index).ToString()));
            index--;
        }

        Debug.Log("score almost set");
        // saves the score and name in preferences
        
        
        PlayerPrefs.SetString(difficulty + "Score" + (index + 1).ToString(), scoreNum.ToString());

        if (playerName.text.Length == 0)
        {
            
            PlayerPrefs.SetString(difficulty + "Name" + (index + 1).ToString(), devNames[new Random().Next(4)]);
            
        }

        else
        {
            PlayerPrefs.SetString(difficulty + "Name" + (index + 1).ToString(), playerName.text);
        }


        Debug.Log("Set Score");


    }

    // checks whether a new high score what achieved
    public void CheckScore()
    {
        
    int scoreNum = Convert.ToInt32(score.text);
    Debug.Log("entering score saver");

    String difficulty = PlayerPrefs.GetInt("Difficulty").ToString();
    // gets player health object to change death text

        
    if (Convert.ToInt32(PlayerPrefs.GetString(difficulty +"Score10")) > scoreNum)return;
    
    Debug.Log("Score in top 10");
    PlayerHealth playerHealth =
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    
    // sets the insertian field to active
    playerNamePanel.SetActive(true);

    // displays a different message
    playerHealth.deathText.text = "NEW HIGHSCORE\nMOTHERFUCKER";
        
    }



}
