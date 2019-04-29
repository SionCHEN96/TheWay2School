using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnimationManager : MonoBehaviour
{
    
    public string nextScene;
    void Start()
    {
        Invoke("LoadStartLevel", 28f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadStartLevel();
        }
    }

    void LoadStartLevel()
    {
        SceneManager.LoadScene(nextScene);
    }
}
