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
    public Dropdown leaderBoardDropdown;
    public GameObject SoundObject;
    private List<GameObject> textList = new List<GameObject>();
    void Start()
    {
        Instantiate(SoundObject);
        if (PlayerPrefs.GetInt("LeaderBoard") != null) leaderBoardDropdown.value = PlayerPrefs.GetInt("LeaderBoard");
        GenerateLeaderBoard();

    }


    void GenerateLeaderBoard()
    {
        
        Debug.Log("generating leaderboard");
        String nameKey = PlayerPrefs.GetInt("LeaderBoard").ToString() + "Name";
        String scoreKey = PlayerPrefs.GetInt("LeaderBoard").ToString() + "Score";

        
        
        GenerateText("Name", 0 , -1, 30);
        GenerateText("High Score", 1 , -1, 30);
        


        for (int i = 1; i <= 10; i++)
        {
            if (PlayerPrefs.HasKey(nameKey + i.ToString()))
            {
                GenerateText(PlayerPrefs.GetString(nameKey + i.ToString()),0,i, 20);

                GenerateText(PlayerPrefs.GetString(scoreKey + i.ToString()),1,i, 20);
                Debug.Log("score displayed");
            }

        }
    }

    // creates a text object and places it in the column and lin
    void GenerateText(String s, int column, int line, int size)
    {
        
        GameObject textObject = new GameObject() ;
        
        Debug.Log("Creating Text object");
        
        textObject.transform.parent = thisCanvas.transform;
        
        Text text = textObject.AddComponent<Text>();
        
        text.text = s;
        text.font = scoreFont;
        text.color = scoreColor;
        text.fontSize = size;

        RectTransform rectTransform = text.GetComponent<RectTransform>();
        
        rectTransform.localPosition = new Vector3(-200 + columnSpacing * column, 100 - linespacing * (line), 0);
        rectTransform.sizeDelta = new Vector2(160, 40);
        
        textList.Add(textObject);
        
    }

    // Resets all of the leader boards
    public void ResetScores()
    {
        for (int i = 0; i < 11; ++i)
        {
            PlayerPrefs.SetString(PlayerPrefs.GetInt("LeaderBoard").ToString() + "Name" + i.ToString(), "Player");
            PlayerPrefs.SetString(PlayerPrefs.GetInt("LeaderBoard").ToString() + "Score" + i.ToString(), "0");
                
                
        }
        
        deleteList();
        GenerateLeaderBoard();
        
        
    }

    // returns to the main menu
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        
    }

    public void LeaderBoardMenuChanged(int index)
    {

        Debug.Log("Changing leaderboard");
        PlayerPrefs.SetInt("LeaderBoard", index);
        //SceneManager.LoadScene(3);

        deleteList();
        GenerateLeaderBoard();
        
    }

    public void deleteList()
    {

        if (textList.Count == 0) return;
        foreach (GameObject textObject in textList)
        {
            Destroy(textObject);
            
        }



    }


}
