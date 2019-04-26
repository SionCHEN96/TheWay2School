using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TipsControllerLvFlashlight : MonoBehaviour
{
    public Text tipText;
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
            tipText.text = "You have fixed the flashlight\nPress  C  to turn it";
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
