using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartSettings(int sceneIndex)
    {

        SceneManager.LoadScene(sceneIndex);

    }
}
