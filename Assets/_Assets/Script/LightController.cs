using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LightController : MonoBehaviour
{
    // Start is called before the first frame updat

    public Slider lightPowerSlider;
    float mapValue;
    public bool isLightOn;

    void Start()
    {
        mapValue = lightPowerSlider.value / 20.0f;
        gameObject.GetComponent<Light>().spotAngle = 90f;
        gameObject.GetComponent<Light>().intensity = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLightOn)
        {
            gameObject.GetComponent<Light>().spotAngle = 90 * Mathf.Cos((Mathf.PI / 2) * (1 - lightPowerSlider.value / mapValue / 20));
            gameObject.GetComponent<Light>().intensity = lightPowerSlider.value / mapValue / 5f + 1f;
        }
        else
        {
            gameObject.GetComponent<Light>().spotAngle = 90f;
            gameObject.GetComponent<Light>().intensity = 5f;
        }

        //Debug.Log("lightRange:" + gameObject.GetComponent<Light>().spotAngle);
        //Debug.Log("LightIntensity:" + gameObject.GetComponent<Light>().intensity);
    }
}
