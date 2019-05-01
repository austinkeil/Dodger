using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public GameObject settingsMenu;

    public Dropdown difficultyDropdown;
    public Dropdown skinDropdown;
    
    List<string> difficulties = new List<string>() {"Easy", "Normal", "Hard"};

    List<string> skins = new List<string>() {"Pies", "Poop", "Spooky"};

    public GameObject SoundObject;
    
    private AudioSource sound;
    
    public Slider sound_volume;


    
    void Start()
    {
        Instantiate(SoundObject);

        
        
        //I keep getting a null reference exception for this line:
        
        
        populateSkinsList();
        
        populateDifficultyList();

        sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<AudioSource>();
        
        sound_volume.value = PlayerPrefs.GetFloat("Sound");
        
        // starts the dropdown menu items at what they are currently set to
        //String.IsNullOrEmpty() will actually check if the int is null, ints otherwise aren't null in c#
        if (!String.IsNullOrEmpty(PlayerPrefs.GetInt("Difficulty").ToString())) difficultyDropdown.value = PlayerPrefs.GetInt("Difficulty");
        
        if (!String.IsNullOrEmpty(PlayerPrefs.GetInt("Skin").ToString())) skinDropdown.value = PlayerPrefs.GetInt("Skin");
        /*
        if (PlayerPrefs.GetInt("Difficulty") != null) difficultyDropdown.value = PlayerPrefs.GetInt("Difficulty");
        
        if (PlayerPrefs.GetInt("Skin") != null) skinDropdown.value = PlayerPrefs.GetInt("Skin");
        */
        Debug.Log("sets audio source to variable");

        
    }
    
    
    
    //sets the preferences difficulty to whatever was selected
    public void DifficultyMenuChanged(int index)
    {

        PlayerPrefs.SetInt("Difficulty", index);

    }

    //sets the preferences skin to whatever was selected
    public void SkinMenuChanged(int index)
    {

        PlayerPrefs.SetInt("Skin", index);

    }

    // loads the main menu
    public void MainMenu(int sceneIndex)
    {

        SceneManager.LoadScene(sceneIndex);


    }

    // populates the difficulty dropdown menu
    public void populateDifficultyList()
    {
        difficultyDropdown.AddOptions(difficulties);
    }

    // populates the skins dropdown list
    public void populateSkinsList()
    {
        skinDropdown.AddOptions(skins);
    }

    public void SoundLevelChanged()
    {
        PlayerPrefs.SetFloat("Sound", sound_volume.value);
        sound.volume = sound_volume.value;
        //Debug.Log("Sound Level changed");
    }
    
}
