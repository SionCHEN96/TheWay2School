using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceRiverContrroller : MonoBehaviour
{
    GameObject iceRiver;

    void Start()
    {
        iceRiver = transform.parent.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            iceRiver.gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
