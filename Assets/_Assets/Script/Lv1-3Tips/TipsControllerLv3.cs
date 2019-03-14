using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TipsControllerLv3 : MonoBehaviour
{
    public Text tipText;
    public Text themeName;

    private void OnTriggerEnter(Collider other)
    {   //welcome
        if (gameObject.name == "WelcomeTrigger" && other.name == "Player")
        {
            themeName.text = "Theme Demo\nThe Road Not Taken";
            SetTipToOne();
        }

        if (gameObject.name=="FireflyTrigger"&& other.name == "Player")
        {
            tipText.text = "WOW! It is firefly !";
            SetTipToOne();
        }

        if (gameObject.name == "FireflyByeTrigger" && other.name == "Player")
        {
            tipText.text = "Goodbye, firefly !";
            SetTipToOne();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
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
