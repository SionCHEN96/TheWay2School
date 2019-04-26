using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider lightPowerSlider;
    public GameObject deathMenu;
    public GameObject flashLighting;

    //game control attributes
    public int flashLightOn;
    private bool isOnGame;
    public bool enableSwitch;
    private bool isDead;
    
    //player state floats
    private float mapValue;
    private float currentValue;

    Animator animator;

    //child gameObjects



    void Start()
    {
        
        mapValue = lightPowerSlider.value / 20.0f;
        animator = gameObject.GetComponent<Animator>();



        isDead = false;
        flashLightOn = -1;
        deathMenu.SetActive(false);
        isOnGame = false;
        enableSwitch = false;

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            isOnGame = true;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            //Debug.Log("C is pressed");
            SwitchFlashlight();
        }


    }

    private void FixedUpdate()
    {
        if (isOnGame)
        {
            if (flashLightOn == 1)
            {
                lightPowerSlider.value -= Time.deltaTime;
            }


            if (lightPowerSlider.value <= 0)
            {
                Die();
            }
        }

        if (flashLightOn==1)
        {
            flashLighting.gameObject.GetComponent<Light>().spotAngle = 90 * Mathf.Cos((Mathf.PI / 2) * (1 - lightPowerSlider.value / mapValue / 20));
            flashLighting.gameObject.GetComponent<Light>().intensity = lightPowerSlider.value / mapValue / 5f + 1f;
        }
        else if(flashLightOn==-1&&!enableSwitch)
        {
            flashLighting.gameObject.GetComponent<Light>().spotAngle = 90f;
            flashLighting.gameObject.GetComponent<Light>().intensity = 5f;
        }


    }

    void SwitchFlashlight()
    {
        if (enableSwitch)
        {
           //Debug.Log("switching");
            
            if (flashLightOn == 1)
            {
                //Debug.Log("turn off");
                flashLighting.SetActive(false);
            }
            else
            {
                flashLighting.SetActive(true);
            }
            flashLightOn = -flashLightOn;
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Batt"))
        {
            lightPowerSlider.value = lightPowerSlider.maxValue;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathTrigger"))
        {
            DieFalling();
        }

        if (other.gameObject.name == "BattTrigger")
        {
            //Debug.Log("flashLightOn:"+flashLightOn);
            flashLightOn = 1;
        }

        if (other.gameObject.name == "LightSwitchTrigger")
        {
            enableSwitch = true;
            //Debug.Log("Enable switch:" + enableSwitch);
        }

        if (other.name == "InsectTrigger")
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        flashLightOn = -1;
        animator.SetBool("isDead", isDead);

        Invoke("TimeStop", 3f);
    }

    void DieFalling()
    {
        isDead = true;
        flashLightOn = -1;
        TimeStop();
    }

    void TimeStop()
    {
        deathMenu.SetActive(true);
        Time.timeScale = 0;
    }

}
