using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);

    }
}
