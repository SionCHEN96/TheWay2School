using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ControlPanelManager : MonoBehaviour
{
    public GameObject controlPanel;

    // Update is called once per frame
    public void DisplayMenu()
    {
        if (Time.timeScale == 1)
        {
            controlPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void CloseMenu()
    {

        controlPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
