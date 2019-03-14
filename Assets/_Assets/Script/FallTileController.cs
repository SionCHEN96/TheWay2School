using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTileController : MonoBehaviour
{
    private float fallDelay = .5f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            StartCoroutine(FallDown());
        }
    }

    IEnumerator FallDown()
    {
        yield return new WaitForSeconds(fallDelay);
       gameObject.GetComponentInParent<Rigidbody>().isKinematic = false;
        gameObject.GetComponentInParent<Rigidbody>().useGravity = true;

        yield return new WaitForSeconds(5);
        gameObject.GetComponentInParent<Rigidbody>().isKinematic = true;


        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }


}
