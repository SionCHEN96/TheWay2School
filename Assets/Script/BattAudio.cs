using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattAudio : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource sound;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sound.Play();
            for (int i = 0; i < transform.childCount; i++)
            {
                GameObject childObj = transform.GetChild(i).gameObject;
                childObj.SetActive(false);
            }
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
