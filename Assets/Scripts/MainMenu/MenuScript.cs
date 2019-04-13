using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    void Start()
    {
        if (!PlayerPrefs.HasKey("Name1"))
        {
            for (int i = 0; i < 11; ++i)
            {
                PlayerPrefs.SetString("Name" + i.ToString(), "Player");
                PlayerPrefs.SetString("Score" + i.ToString(), "0");
                
                
            }

        }


    }

    // Start is called before the first frame update
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);

    }
}
