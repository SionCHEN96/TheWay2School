using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider LightPowerSlider;
    public GameObject deathMenu;
    public GameObject FlashLighting;

    private float playerHealth;
    private bool isDead;
    private bool flashLightOn;
    Animator animator;
    bool isOnGame;



    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        isDead = false;
        flashLightOn = false;
        deathMenu.SetActive(false);
        isOnGame = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            isOnGame = true;
        }

        if (isOnGame&&flashLightOn)
        {
            LightPowerSlider.value -= Time.deltaTime;
            playerHealth = LightPowerSlider.value;
            //Debug.Log("Player health:" + playerHealth);
            if (playerHealth <= 0)
            {
                Die();
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Batt"))
        {
            LightPowerSlider.value = LightPowerSlider.maxValue;
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
            Debug.Log(flashLightOn);
            flashLightOn = true;
            FlashLighting.GetComponent<LightController>().isLightOn = flashLightOn;
        }
    }
    void Die()
    {
        isDead = true;
        flashLightOn = false;
        animator.SetBool("isDead", isDead);

        Invoke("TimeStop", 3f);
    }

    void DieFalling()
    {
        isDead = true;
        flashLightOn = false;
        TimeStop();
    }

    void TimeStop()
    {
        deathMenu.SetActive(true);
        Time.timeScale = 0;
    }

}
