using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    
    public GameObject pauseMenu;
    public bool isPaused;


    public Slider sound_volume;

    public AudioSource sound;
    // Start is called before the first frame update


    void Start()
    {
        sound = GameObject.FindGameObjectWithTag("ProjectileGenerationArea").GetComponent<AudioSource>();
        sound_volume.value = PlayerPrefs.GetFloat("Sound");
        
    }

    void Update()
    {
        // checks to see if the escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                
                isPaused = true;
                // activates the pause menu
                pauseMenu.SetActive(true);
                // freezes the game
                Time.timeScale = 0f;

            }


        }
    }

    public void ResumeGame()
    {
        
        isPaused = false;
        // deactivates the pause menu
        pauseMenu.SetActive(false);
        // unfreezes the game
        Time.timeScale = 1f;

    }

    
    public void ReturnToMain(int sceneIndex)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneIndex);
    }

    // function for all of the buttons on the death menu
    public void DeathMenuButton(int sceneIndex)
    {
        
        // saves the score
        GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreScript>().SaveScore();
        // restarts the game or goes to the main menu
        SceneManager.LoadScene(sceneIndex);
        
    }
    
    public void SoundLevelChanged()
    {
        PlayerPrefs.SetFloat("Sound", sound_volume.value);
        sound.volume = sound_volume.value;

    }

}
