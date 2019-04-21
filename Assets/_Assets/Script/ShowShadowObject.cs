using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowShadowObject : MonoBehaviour

{

    private GameObject player;
    bool showSelf;

    private void Start()
    {
        showSelf = false;
        player = GameObject.Find("Player");
        //Debug.Log("find player");
    }


    private void Update()
    {

        if (player.GetComponent<PlayerHealth>().flashLightOn == -1)
        {
            showSelf = true;
        }
        else
        {
            showSelf = false;
        }
    }

    private void FixedUpdate()
    {
        if (gameObject.CompareTag("Light"))
        {
            gameObject.GetComponent<Light>().enabled = showSelf;
        }


        if (gameObject.CompareTag("Tile"))
        {
            gameObject.GetComponent<MeshRenderer>().enabled = showSelf;
            gameObject.GetComponent<BoxCollider>().enabled = showSelf;
        }

        if (gameObject.CompareTag("Envi"))
        {
            gameObject.GetComponent<MeshRenderer>().enabled = showSelf;
        }

    }

}
