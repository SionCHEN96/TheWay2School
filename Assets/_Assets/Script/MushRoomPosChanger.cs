using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoomPosChanger : MonoBehaviour
{
    private GameObject player;

    public float minPosY;
    public float maxPosY;

    float isMoving;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        minPosY = -12f;
        maxPosY=0f;
        
        isMoving = -1;

        transform.position = new Vector3(0, minPosY, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.GetComponent<PlayerHealth>().flashLightOn == -1)
        {
            if (gameObject.transform.position.y < maxPosY) { 
                Rise();
            }
            else
            {
                gameObject.transform.position=new Vector3(0,maxPosY,0);
            }

        }

        if(player.GetComponent<PlayerHealth>().flashLightOn == 1)
        {
            if (gameObject.transform.position.y > minPosY)
            {
                Down();
            }
            else
            {
                gameObject.transform.position = new Vector3(0, minPosY, 0);
            }
        }

    }

    void Rise()
    {
        transform.Translate(Vector3.up *2f* Time.deltaTime);
    }

    void Down()
    {
        transform.Translate(-Vector3.up *8f* Time.deltaTime);
    }
}
