using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public GameObject settingsMenu;

    public Dropdown DifficultyDropdown;
    public Dropdown SkinDropdown;
    
    List<string> Difficulties = new List<string>() {"Easy", "Normal", "Hard"};

    List<string> Skins = new List<string>() {"Pies", "Poop", "Spooky"};
    
    void Start()
    {
        
        populateSkinsList();
        populateDifficultyList();
    }
    
    
    
    public void DifficultyMenuChanged(int index)
    {
        
        
        
    }

    public void MainMenu(int sceneIndex)
    {

        SceneManager.LoadScene(sceneIndex);


    }

    public void populateDifficultyList()
    {
        DifficultyDropdown.AddOptions(Difficulties);
    }

    public void populateSkinsList()
    {
        SkinDropdown.AddOptions(Skins);
    }

}
