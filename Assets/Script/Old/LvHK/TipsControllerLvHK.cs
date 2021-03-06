﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TipsControllerLvHK : MonoBehaviour
{
    public Text tipText;
    public Text themeName;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {   //welcome
        if (gameObject.name == "WelcomeTrigger" && other.name == "Player")
        {
            tipText.text = "press LEFT or RIGHT to move";
           themeName.text = "Theme \nHong Kong";
            SetTipToOne();
        }

        //run
        if (gameObject.name == "RunTrigger" && other.name == "Player")
        {
            tipText.text = "hold SHIFT to run";
            SetTipToOne();
        }

        //jump
        if (gameObject.name == "JumpTrigger" && other.name == "Player")
        {
            tipText.text = "press SPACE to jump";
            SetTipToOne();
        }
        //crawl
        if (gameObject.name == "CrawlTrigger" && other.name == "Player")
        {
            tipText.text = "hold CTRL to crawl";
            SetTipToOne();
        }

        if (gameObject.name == "SchoolTrigger" && other.name == "Player")
        {
            tipText.text = "Well done, you are arriving school!";
            SetTipToOne();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name=="Player")
        {
            SetTipToTwo();
        }
        Invoke("SetTipToZero", 1f);
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
