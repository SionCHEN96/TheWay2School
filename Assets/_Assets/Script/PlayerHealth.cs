using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider LightPowerSlider;
    public GameObject deathMenu;
    private float playerHealth;
    private bool isDead = false;
    bool isOnGame;
    void Start()
    {
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
        if (isOnGame)
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Batt"))
        {
            other.gameObject.SetActive(false);
            LightPowerSlider.value = 20;
        }

        if (other.name == "DeathTrigger")
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        deathMenu.SetActive(true);
        Time.timeScale = 0;
    }

}
