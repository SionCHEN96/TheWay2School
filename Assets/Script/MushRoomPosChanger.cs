using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class MushRoomPosChanger : MonoBehaviour
{
    private GameObject player;

    public float minPosY=-12f;
    public float maxPosY=0f;

    float isMoving;
    float posX;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        posX = transform.position.x;
        
        isMoving = -1;

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
                gameObject.transform.position=new Vector3(posX,maxPosY,0);
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
                gameObject.transform.position = new Vector3(posX, minPosY, 0);
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
