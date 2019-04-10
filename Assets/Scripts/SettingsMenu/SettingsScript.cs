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

        if (PlayerPrefs.GetInt("Difficulty") != null) difficultyDropdown.value = PlayerPrefs.GetInt("Difficulty");
        
        if (PlayerPrefs.GetInt("Skin") != null) skinDropdown.value = PlayerPrefs.GetInt("Skin");
    }
    
    
    
    public void DifficultyMenuChanged(int index)
    {


        PlayerPrefs.SetInt("Difficulty", index);

    }

    public void SkinMenuChanged(int index)
    {


        PlayerPrefs.SetInt("Skin", index);

    }

    public void MainMenu(int sceneIndex)
    {

        SceneManager.LoadScene(sceneIndex);


    }

    public void populateDifficultyList()
    {
        difficultyDropdown.AddOptions(difficulties);
    }

    public void populateSkinsList()
    {
        skinDropdown.AddOptions(skins);
    }

}
