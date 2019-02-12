using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider LightPowerSlider;
    private float playerHealth;
    void Start()
    {
        LightPowerSlider.value = 20f;

    }

    // Update is called once per frame
    void Update()
    {
        LightPowerSlider.value-=Time.deltaTime;
        //Debug.Log(LightPowerSlider.value);
        playerHealth = LightPowerSlider.value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Batt"))
        {
            other.gameObject.SetActive(false);
            LightPowerSlider.value = 20;
        }
    }
}
