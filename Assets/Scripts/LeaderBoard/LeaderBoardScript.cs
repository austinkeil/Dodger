using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeaderBoardScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject thisCanvas;
    public Font scoreFont;
    public Color scoreColor;
    public int linespacing = 25;
    public int columnSpacing = 400;
    
        
    void Start()
    {
        GenerateLeaderBoard();

    }


    void GenerateLeaderBoard()
    {
        String nameKey = "Name";
        String scoreKey = "Score";

        
        
        generateText("Name", 0 , -1, 30);
        generateText("High Score", 1 , -1, 30);
        


        for (int i = 1; i <= 10; i++)
        {
            if (PlayerPrefs.HasKey(nameKey + i.ToString()))
            {
                generateText(PlayerPrefs.GetString(nameKey + i.ToString()),0,i, 20);

                generateText(PlayerPrefs.GetString(scoreKey + i.ToString()),1,i, 20);
                
            }

        }
    }

    // creates a text object and places it in the column and lin
    void generateText(String s, int column, int line, int size)
    {
        
        GameObject textObject = new GameObject() ;

        textObject.transform.parent = thisCanvas.transform;
        
        Text text = textObject.AddComponent<Text>();
        
        text.text = s;
        text.font = scoreFont;
        text.color = scoreColor;
        text.fontSize = size;

        RectTransform rectTransform = text.GetComponent<RectTransform>();
        
        rectTransform.localPosition = new Vector3(-200 + columnSpacing * column, 100 - linespacing * (line), 0);
        rectTransform.sizeDelta = new Vector2(160, 40);
        
        
    }

    // Resets all of the leader boards
    public void ResetScores(int sceneIndex)
    {
        for (int i = 0; i < 11; ++i)
        {
            PlayerPrefs.SetString("Name" + i.ToString(), "Player");
            PlayerPrefs.SetString("Score" + i.ToString(), "0");
                
                
        }
        
        SceneManager.LoadScene(sceneIndex);
        
        
    }

    // returns to the main menu
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        
    }



}
