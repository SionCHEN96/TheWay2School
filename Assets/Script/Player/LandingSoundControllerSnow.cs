using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingSoundControllerSnow : MonoBehaviour
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
        if (player.gameObject.GetComponent<PlayerHealthSnow>().IsOnGame)
        {
            if (other.gameObject.tag == "Tile" && !player.GetComponent<PlayerMovementSnow>().Grounded())
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
