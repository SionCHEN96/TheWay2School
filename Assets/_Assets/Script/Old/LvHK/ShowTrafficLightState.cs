using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTrafficLightState : MonoBehaviour
{
    // Start is called before the first frame update
    Material mat;
    public bool isRed;

    private void Awake()
    {
        mat = gameObject.GetComponent<MeshRenderer>().materials[0];
    }
    // Update is called once per frame
    void Update()
    {
        if (mat.name.Equals("StopSignColorRed"))
        {
            Debug.Log("Light is red");
            isRed = true;
        }
        else if (mat.name.Equals("StopSignColorGreen"))
        {
            isRed = false;
        }
    }
}
