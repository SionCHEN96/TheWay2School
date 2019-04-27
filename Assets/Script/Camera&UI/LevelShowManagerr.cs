using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelShowManagerr : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] level;
    void Start()
    {
        int levelProcess=PlayerPrefs.GetInt("Level");

        for(int i = 0; i < levelProcess; i++)
        {
            level[i].gameObject.SetActive(true);
        }
    }

}
