using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSoundControllerSnow : MonoBehaviour
{
    AudioSource lightSound;
    GameObject player;
    void Start()
    {
        lightSound = GetComponent<AudioSource>();
        player = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerHealthSnow>().enableSwitch)
        {
            if (Input.GetKey(KeyCode.C))
            {
                lightSound.Play();
            }
        }
    }
}
