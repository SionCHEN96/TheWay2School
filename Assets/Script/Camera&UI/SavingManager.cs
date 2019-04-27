using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingManager : MonoBehaviour
{
    public int level;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            int levelDone = PlayerPrefs.GetInt("Level");
            if (level >= levelDone)
            {
                PlayerPrefs.SetInt("Level", level);
            }
        }
    }
}
