using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestJump : MonoBehaviour
{
    private CharacterController ct;

    private float vV;
    private float gravity = -14.0f;
    private float jumpForce = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        ct = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ct.isGrounded)
        {
            vV = -gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                vV = jumpForce;
            }
        }
        else
        {
            vV -= gravity * Time.deltaTime*Time.deltaTime;
        }
        Vector3 moveVector = new Vector3(0, vV, 0);
        ct.Move(moveVector * Time.deltaTime);
    }
}
