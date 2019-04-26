using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public GameObject soundObject;
    
    void Start()
    {
        Instantiate(soundObject);
        if(!PlayerPrefs.HasKey("Difficulty")) PlayerPrefs.SetInt("Difficulty", 0);
        if(!PlayerPrefs.HasKey("Sound"))PlayerPrefs.SetFloat("Sound", 1f);
        PlayerPrefs.SetInt("LeaderBoard", PlayerPrefs.GetInt("Difficulty"));
        // checks to see if the leaderboard has any values
        if (!PlayerPrefs.HasKey("0Name1"))
        {
            for (int j = 0; j < 3; j++)
            {


                for (int i = 0; i < 11; ++i)
                {
                    PlayerPrefs.SetString(j.ToString() + "Name" + i.ToString(), "Player");
                    PlayerPrefs.SetString(j.ToString() + "Score" + i.ToString(), "0");


                }
            }
        }


    }

    
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
