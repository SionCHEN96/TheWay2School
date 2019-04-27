using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyController : MonoBehaviour
{
    public Transform target;
    public float backDist = 2f;
    public float topDist = 2f;
    //public float smooth = 1f;

    public GameObject fireTrigger;

    Vector3 distance;
    bool isGo=false;



    // Start is called before the first frame update
    void Start()
    {
       target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (fireTrigger.GetComponent<FireflyTrigger>().IsTrig&&!isGo)
        {
            isGo = true;
        }

       Vector3 offset = -target.forward * backDist + target.up * topDist;


        if (isGo) {
            transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime);
            transform.rotation = target.rotation;
            //transform.position = Vector3.Lerp(transform.position, target.position + distance, smooth);
        }
    }
}
