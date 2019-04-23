using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    void Start()
    {
        // checks to see if the leaderboard has any values
        if (!PlayerPrefs.HasKey("Name1"))
        {
            for (int i = 0; i < 11; ++i)
            {
                PlayerPrefs.SetString("Name" + i.ToString(), "Player");
                PlayerPrefs.SetString("Score" + i.ToString(), "0");
                
                
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
