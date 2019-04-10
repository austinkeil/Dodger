using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject thisCanvas;
    public Font scoreFont;
    public Color scoreColor;
    
    void Start()
    {
        String nameKey = "Name";
        String scoreKey = "Score";

        
        
        generateText("Name", 0 , 0);
        generateText("High Score", 1 , 0);
        


        for (int i = 1; i <= 10; i++)
        {
            if (PlayerPrefs.HasKey(nameKey + i.ToString()))
            {
                generateText(PlayerPrefs.GetString(nameKey + i.ToString()),0,i);

                generateText(PlayerPrefs.GetString(scoreKey + i.ToString()),1,i);
                
            }

            

        }

    }

    void generateText(String s, int column, int line)
    {
        GameObject textObject = new GameObject() ;

        textObject.transform.parent = thisCanvas.transform;
        
        Text text = textObject.AddComponent<Text>();
        
        text.text = s;
        text.font = scoreFont;
        text.color = scoreColor;

        RectTransform rectTransform = text.GetComponent<RectTransform>();
        
        rectTransform.localPosition = new Vector3(-200 + 400 * column, 100 - 15 * (line), 0);
        rectTransform.sizeDelta = new Vector2(160, 30);
        
        
    }

    // Update is called once per frame

}
