using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TipsControllerLv2 : MonoBehaviour
{
    public Text tipText;
    public Text themeName;

    private void OnTriggerEnter(Collider other)
    {   //welcome
        if (gameObject.name == "FlashlightTrigger" && other.name == "Player")
        {
            tipText.text = "You can see the POWER of your flashlight\n at the TOP of the screen";
            themeName.text = "Theme 2\nBattered flashlight";
            SetTipToOne();
        }

        //Battery
        if (gameObject.name == "BattTrigger" && other.name == "Player")
        {
            tipText.text = "Collect the BATTERY and charge the flashlight";
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
