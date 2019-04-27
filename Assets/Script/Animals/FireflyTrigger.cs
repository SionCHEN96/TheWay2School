using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyTrigger: MonoBehaviour
{
    bool isTrig=false;

    public bool IsTrig { get => isTrig; set => isTrig = value; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            IsTrig = true;
            Debug.Log("TT");
        }
    }
}
