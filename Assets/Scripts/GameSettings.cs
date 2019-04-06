using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameSettings Instance;
    public String Difficulty;
    public String Skin;
    
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);

            Instance = this;
        }
        
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

    }

}
