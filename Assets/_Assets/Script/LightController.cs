using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LightController : MonoBehaviour
{
    // Start is called before the first frame updat

    public Slider lightPowerSlider;
    float mapValue;

    void Start()
    {
        mapValue = lightPowerSlider.value / 20.0f;
        gameObject.GetComponent<Light>().spotAngle = 80f;
        gameObject.GetComponent<Light>().intensity = 6f;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Light>().spotAngle = 80*Mathf.Cos((Mathf.PI/2)*( 1-lightPowerSlider.value/mapValue/20));
        gameObject.GetComponent<Light>().intensity = lightPowerSlider.value/mapValue / 3.2f + 1f;

        //Debug.Log("lightRange:" + gameObject.GetComponent<Light>().spotAngle);
        //Debug.Log("LightIntensity:" + gameObject.GetComponent<Light>().intensity);
    }
}
