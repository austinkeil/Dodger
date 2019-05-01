using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public static SoundScript sound;
    public AudioSource music;
    // Start is called before the first frame update
    void Awake()
    {
        if (sound == null)
        {
            DontDestroyOnLoad(gameObject);
            sound = this;
        }
        else if (sound != this)
        {
            Destroy (gameObject);
        }
        
        if (PlayerPrefs.HasKey("Sound")) music.volume = PlayerPrefs.GetFloat("Sound");
    }
    

    public void InvertMusic()
    {

        music.pitch = -1f;

        Debug.Log("Stopping Sound?");

    }

    public void NormalMusic()
    {

        music.pitch = 1f;

        Debug.Log("Stopping Sound?");


    }

    public void IncreasePitch()
    {

        music.pitch *= 1.005f;

    }

}
