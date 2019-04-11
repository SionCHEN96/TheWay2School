using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovementTest2 : MonoBehaviour
{
    [System.Serializable]
    public class MoveSettings
    {
        public float forwardVel = 10;
        public float rotateVel = 100;
        public float jumpVel = 25;
        public float distToGrounded=0.2f;
        public LayerMask ground;
    }

    [System.Serializable]
    public class PhysSettings
    {
        public float downAccel = 0.75f;
    }

    [System.Serializable]
    public class InputSettings
    {
        public float inputDelay = 0.1f;
        public string FORWARD_AXIS = "Vertical";
        public string TURN_AXIS = "Horizontal";
        public string JUMP_AXIS = "Jump";
    }

    public MoveSettings moveSetting = new MoveSettings();
    public PhysSettings physSetting = new PhysSettings();
    public InputSettings inputSetting = new InputSettings();

    Vector3 velocity = Vector3.zero;
    Quaternion targetRotation;
    Rigidbody rBody;
    float forwardInput, turnInput,jumpInput;

    public Quaternion TargetRotation
    {
        get { return TargetRotation; }
    }

    bool Grounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, moveSetting.distToGrounded, moveSetting.ground);
    }

    private void Start()
    {
        targetRotation = transform.rotation;

        if (GetComponent<Rigidbody>())
        {
            rBody = GetComponent<Rigidbody>();
        }
        else
        {
            Debug.LogError("The character needs a rigidbody");
        }

        forwardInput = turnInput=jumpInput= 0;
    }

    void GetInput()
    {
        forwardInput = Input.GetAxis(inputSetting.FORWARD_AXIS);
        turnInput = Input.GetAxis(inputSetting.TURN_AXIS);
        jumpInput = Input.GetAxisRaw(inputSetting.JUMP_AXIS);
    }

    private void Update()
    {
        GetInput();
        Turn();

        if (Grounded())
        {
            Debug.Log("Grounded");
        }
    }

    private void FixedUpdate()
    {
        Run();
        Jump();

        rBody.velocity = transform.TransformDirection(velocity);
    }

    void Run()
    {
        if (Mathf.Abs(forwardInput) >inputSetting. inputDelay)
        {
            // rBody.velocity = transform.forward * forwardInput * moveSetting. forwardVel;
            velocity.z = moveSetting.forwardVel * forwardInput;
        }
        else
        {
            //rBody.velocity = Vector3.zero;
            velocity.z = 0;
        }
    }

    void Turn()
    {
        if (Mathf.Abs(turnInput) >inputSetting. inputDelay)
        {
            targetRotation *= Quaternion.AngleAxis(moveSetting. rotateVel * turnInput * Time.deltaTime, Vector3.up);
        }
        transform.rotation = targetRotation;
    }

    void Jump()
    {
        if (jumpInput > 0 && Grounded())
        {
            //jump
            Debug.Log("Jumping");
            velocity.y = moveSetting.jumpVel;
        }
        else if(jumpInput==0&&Grounded())
        {
            Debug.Log("NotJumping");
            velocity.y = 0;
        }
        else
        {
            //decrease velocity.y
            velocity.y -= physSetting.downAccel;
        }
    }



}
