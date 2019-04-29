using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingSoundController : MonoBehaviour
{
    AudioSource landingSound;
    GameObject player;

    private void Start()
    {
        landingSound = GetComponent<AudioSource>();
        player = transform.parent.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player.gameObject.GetComponent<PlayerHealth>().IsOnGame)
        {
            if (other.gameObject.tag == "Tile" && !player.GetComponent<PlayerMovement>().Grounded())
            {
                Debug.Log("Landing");
                Invoke("PlaySound", 0.1f);
            }
        }
    }

    void PlaySound()
    {
        landingSound.Play();
    }
}
