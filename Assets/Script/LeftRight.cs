using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRight : MonoBehaviour
{
    Vector3 orinPos;
    public float walkingDist=8f;
    public float speed = 5f;
    public int state;

    float rightBound;
    float leftBound;
    

    // Start is called before the first frame update
    void Start()
    {
        orinPos = transform.position;
        leftBound = orinPos.x -walkingDist;
        rightBound = orinPos.x + walkingDist;

        state = 1;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
            if (state == 1)
            {
                Go();
                if (transform.position.x >= rightBound)
                {
                    state = -1;
                    transform.rotation = Quaternion.Euler(0, -90, 0);
                }
            }

            if (state == -1)
            {
                Go();
                if (transform.position.x <= leftBound)
                {
                    state = 1;
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                }
            }

    }

    void Go()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

}
