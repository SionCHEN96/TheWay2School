using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TrafficLightSign;
    public Animator carAnimator;

    void Start()
    {

    }
     
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Player");
        if (other.CompareTag("Player"))
        {
            if (!TrafficLightSign.GetComponent<ShowTrafficLightState>().isRed)
            {
                Debug.Log("Green");
                carAnimator.SetBool("Trig", false);
            }
            else 
            {
                Debug.Log("Red");
                carAnimator.SetBool("Trig", true);
            }
        }
    }
}
