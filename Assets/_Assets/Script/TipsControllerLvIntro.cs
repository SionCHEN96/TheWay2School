﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TipsControllerLvIntro : MonoBehaviour
{
    public Text tipText;
    public Text themeName;
    public GameObject flashLightIcon;

    private void Start()
    {
        flashLightIcon.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {   //welcome
        if (gameObject.name == "WelcomeTrigger" && other.name == "Player")
        {
            tipText.color = new Color(233, 238, 125, 0);
            themeName.text = "The 1 day to school\nThe Broken Flashlight";
            tipText.text = "Press  LEFT and RIGHT  to move";
            SetTipToOne();
        }

        if (gameObject.name == "RunTrigger" && other.name == "Player")
        {
            tipText.color = new Color(233, 238, 125, 0);
            tipText.text = "Hold  SHIFT  to Run";
            SetTipToOne();
        }

        if (gameObject.name == "JumpTrigger" && other.name == "Player")
        {
            tipText.color = new Color(233, 238, 125, 0);
            tipText.text = "Press  SPACE  to Jump";
            SetTipToOne();
        }

        if (gameObject.name == "CrawlTrigger" && other.name == "Player")
        {
            tipText.color =new Color(233, 238, 125, 0);
            tipText.text = "Hold  CTRL  to Crawl";
            SetTipToOne();
        }

        if (gameObject.name == "BattTrigger" && other.name == "Player")
        {
            tipText.color = Color.red;
            tipText.text = "Your Flashlight is broken\nCollect Battery to charge it";
            flashLightIcon.SetActive(true);
            flashLightIcon.GetComponent<Animator>().SetBool("On", true);
            SetTipToOne();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            SetTipToTwo();
        }
        Invoke("SetTipToZero", 0.5f);
    }

    void SetTipToZero()
    {
        tipText.text = "";
        tipText.GetComponent<Animator>().SetInteger("Flow", 0);
    }

    void SetTipToOne()
    {
        tipText.GetComponent<Animator>().SetInteger("Flow", 1);
    }

    void SetTipToTwo()
    {
        tipText.GetComponent<Animator>().SetInteger("Flow", 2);
    }
}