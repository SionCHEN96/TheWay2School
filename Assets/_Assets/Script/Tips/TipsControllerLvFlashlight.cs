using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TipsControllerLvFlashlight : MonoBehaviour
{
    public Text tipText;
    public Text themeName;
    public GameObject flashLightIcon;

    private void Start()
    {
        gameObject.SetActive(true);
        flashLightIcon.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {  

        if (gameObject.name == "LightSwitchTrigger" && other.name == "Player")
        {
            tipText.color = new Color(233, 238, 125, 255);
            tipText.text = "You have fixed the flashlight\nPress  C  to turn it";
            themeName.text = "The 2 day to school\nThe Magic of Light";
            SetTipToOne();
        }

        if (gameObject.name == "BattTrigger"&& other.name == "Player"){
            flashLightIcon.SetActive(true);
            flashLightIcon.GetComponent<Animator>().SetBool("On", true);
            gameObject.SetActive(false);
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
