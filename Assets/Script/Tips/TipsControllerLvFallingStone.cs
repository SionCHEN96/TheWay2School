using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TipsControllerLvFallingStone : MonoBehaviour
{
    public Text tipText;
    public GameObject flashLightIcon;

    private void Start()
    {
        gameObject.SetActive(true);
        flashLightIcon.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {

        if (gameObject.name == "BattTrigger" && other.name == "Player")
        {
            tipText.text = "The road seems not so good";
            flashLightIcon.SetActive(true);
            flashLightIcon.GetComponent<Animator>().SetBool("On", true);
            SetTipToOne();
        }



    }

    private void OnTriggerEnter(Collider other)
    {

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
