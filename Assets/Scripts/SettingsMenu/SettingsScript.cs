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
    }
    
    
    
    public void DifficultyMenuChanged(int index)
    {

        GameSettings.Instance.Difficulty = difficulties[index];

    }

    public void SkinMenuChanged(int index)
    {

        GameSettings.Instance.Skin = skins[index];

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
