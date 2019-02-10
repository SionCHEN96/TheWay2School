using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; 
    public float smooth = 0.5f;
    Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        distance = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + distance, smooth);
    }
}
