using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTileController : MonoBehaviour
{
    private float fallDelay = 10f;
    bool isFalling = false;
    float timeWhenCollides;
    float timeToFall;

    Rigidbody rrBody;


    private void Start()
    {
        timeWhenCollides = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player is comming");
        if (other.CompareTag("Player"))
        {
            timeWhenCollides = Time.time;
            Debug.Log(gameObject.name + timeWhenCollides);
        }
    }

    private void Update()
    {

        timeToFall = timeWhenCollides + Time.deltaTime;
        Debug.Log(gameObject.name+ timeToFall);
        if (timeToFall >= timeWhenCollides + fallDelay)
        {
            FallDown();
        }
    }

    void FallDown()
    {
        //gameObject.GetComponentInParent<Rigidbody>().isKinematic = false;
        gameObject.GetComponentInParent<Rigidbody>().useGravity = true;

        gameObject.SetActive(false);
    }


}
