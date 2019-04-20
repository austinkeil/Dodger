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
    
    void Start()
    {
        
        populateSkinsList();
        
        populateDifficultyList();
        
        // starts the dropdown menu items at what they are currently set to
        if (PlayerPrefs.GetInt("Difficulty") != null) difficultyDropdown.value = PlayerPrefs.GetInt("Difficulty");
        
        if (PlayerPrefs.GetInt("Skin") != null) skinDropdown.value = PlayerPrefs.GetInt("Skin");
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

}
