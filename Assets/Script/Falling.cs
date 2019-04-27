using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    // Start is called before the first frame update
    bool isCollided;
    bool isFalling;

    public float fallDelay;
    float returnDelay=4f;
    Vector3 pos;

    void Start()
    {
        pos = transform.position;
        isCollided = false;
        isFalling = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCollided)
        {
            Invoke("SetFall", fallDelay);
        }

        if (isFalling)
        {
            FallingDown();
        }
        if (isFalling && isCollided)
        {
            Invoke("ResetPos", returnDelay);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollided = true;
        }
    }

    void SetFall()
    {
        isFalling = true;
    }
    void FallingDown()
    {
        //Debug.Log("Falling");
        transform.Translate(-Vector3.up * Time.deltaTime*10f, Space.World);
    }

    private void ResetPos()
    {
        transform.position = pos;
        isFalling = false;
        isCollided = false;
    }
}
