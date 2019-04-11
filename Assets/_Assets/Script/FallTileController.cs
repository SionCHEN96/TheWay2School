using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTileController : MonoBehaviour
{
    private float fallDelay = 10f;
    bool isFalling = false;


    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player is comming");
        if (other.CompareTag("Player"))
        {
            isFalling = true;
        }
    }

    private void Update()
    {
        if (isFalling)
        {
            Invoke("FallDown", fallDelay);
        }
    }

    void FallDown()
    {
        gameObject.GetComponentInParent<Rigidbody>().isKinematic = false;
        gameObject.GetComponentInParent<Rigidbody>().useGravity = true;

        gameObject.SetActive(false);
    }


}
