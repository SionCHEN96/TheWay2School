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
    void Start()
    {
        LightPowerSlider.value = 20f;
        deathMenu.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        LightPowerSlider.value-=Time.deltaTime;
        //Debug.Log(LightPowerSlider.value);
        playerHealth = LightPowerSlider.value;
        Debug.Log("Player health:" + playerHealth);
        if (playerHealth <= 0)
        {
            Die();
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
