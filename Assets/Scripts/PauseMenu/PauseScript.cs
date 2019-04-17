using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;

    
    
    
    
    // Start is called before the first frame update

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;

            }


        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

    }

    public void ReturnToMain(int sceneIndex)
    {
        Time.timeScale = 1f;
      //  if(!GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().isDead)GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>().CheckScore();
        SceneManager.LoadScene(sceneIndex);
    }

    public void DeathMenuButton(int sceneIndex)
    {
        GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>().SaveScore();
        SceneManager.LoadScene(sceneIndex);
        
    }

}
