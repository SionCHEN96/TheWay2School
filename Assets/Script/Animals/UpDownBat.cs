using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownBat : MonoBehaviour
{
    public Animator animator;

    Vector3 orinPos;
    public float floatingDist=5f;
    public float speed=3f;

    float upBound;
    float downBound;
    int state;

    bool isTrig;

    // Start is called before the first frame update
    void Start()
    {

        orinPos = transform.position;
        upBound = orinPos.y + floatingDist;
        downBound = orinPos.y - floatingDist;
        state = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isTrig)
        {
            if (state == 1)
            {
                GoUp();
                if (transform.position.y >= upBound)
                {
                    state = -1;
                }
            }

            if (state == -1)
            {
                GoDown();
                if (transform.position.y <= downBound)
                {
                    state = 1;
                }
            }
        }
        else
        {
            animator.SetBool("IsTrirg", isTrig);
        }
    }

    void GoUp()
    {
        transform.Translate(Vector3.up*speed*Time.deltaTime);
    }

    void GoDown()
    {
        transform.Translate(-Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isTrig = true;
        }
    }

}
