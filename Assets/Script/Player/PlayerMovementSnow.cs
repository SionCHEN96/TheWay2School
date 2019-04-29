using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class PlayerMovementSnow : MonoBehaviour
{
    [System.Serializable]
    public class MoveSettings
    {
        public float forwardVel = 4;
        public float jumpVel = 10;
        public float distToGrounded = 0.15f;
        public LayerMask ground;
    }

    [System.Serializable]
    public class PhysSettings
    {
        public float downAccel = 0.75f;
        public GameObject groundDetection;
    }

    [System.Serializable]
    public class InputSettings
    {
        public float inputDelay = 0.1f;
        public string FORWARD_AXIS = "Horizontal";
        public string JUMP_AXIS = "Jump";
    }

    public MoveSettings moveSetting = new MoveSettings();
    public PhysSettings physSetting = new PhysSettings();
    public InputSettings inputSetting = new InputSettings();


    //components
    public GameObject winMenu;
    public AudioClip[] movementAudio;
    AudioSource audioSource;
    private Animator animator;
    private Rigidbody rBody;
    private CapsuleCollider capsule;
    Vector3 velocity = Vector3.zero;

    float forwardInput, jumpInput,velMult;
    int direction = 1;

    //state controller
    private bool isRun = false;
    private bool isCrawl = false;
    private bool isUnderTile = false;
    private bool isDead=false;
    private bool isWin = false;
    private bool enableRun = false;

    public bool IsDead { get => isDead; set => isDead = value; }

    public bool Grounded()
    {
        if (physSetting.groundDetection.GetComponent<GroundDetection>().isGround)
        {
            return true;
        }

      return  Physics.Raycast(transform.position, Vector3.down, moveSetting.distToGrounded, moveSetting.ground);
    }

    void GetInput()
    {
        forwardInput = Input.GetAxis(inputSetting.FORWARD_AXIS);
        jumpInput = Input.GetAxisRaw(inputSetting.JUMP_AXIS);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = this.GetComponent<Animator>();
        capsule = GetComponent<CapsuleCollider>();
        if (GetComponent<Rigidbody>())
        {
            rBody = this.GetComponent<Rigidbody>();
        }
        else
        {
            Debug.LogError("Cannot find Rigidbody");
        }

        forwardInput = velMult= jumpInput = 0;
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log("is grounded: "+Grounded());
        //if (jumpInput > 0)
        //{
        //    Debug.Log("Jump pressed");
        //
            GetRun();
            GetCrawl();
            GetInput();
       
        CallAnimation();
        PlayAudio();

    }

    private void FixedUpdate()
    {
        SetRotation();
        horizontalMovement();
        Jump();
        if (!isDead&!isWin)
        {
            rBody.velocity = velocity;
        }
        //Debug.Log("velocity x: " + velocity.x);
        
    }


    void SetRotation()
    {
        if (forwardInput > 0)
        {
            direction = 1;
        }
        else if (forwardInput < 0)
        {
            direction = -1;
        }
        this.transform.rotation = Quaternion.Euler(0, direction * 90, 0);
    }

    void GetRun()
    {
        //if is run
        if (enableRun)
        {
            if (!isCrawl)
            {
                if (Input.GetKey(KeyCode.LeftShift) && forwardInput != 0)
                {
                    isRun = true;
                    velMult = 3;
                }
                else if (forwardInput == 0 || !Input.GetKey(KeyCode.LeftShift))
                {
                    isRun = false;
                    velMult = 0;
                }
            }
        }
    }

    void GetCrawl()
    {
        //if is crawl
        if (!isRun)
        {
            if ((Input.GetKey(KeyCode.LeftControl) && (forwardInput != 0)))
            {
                isCrawl = true;
                velMult = 0.4f;
                this.GetComponent<CapsuleCollider>().center = new Vector3(0, 4f, 0);
                this.GetComponent<CapsuleCollider>().height = 9f;
            }
            else if (!Input.GetKey(KeyCode.LeftControl) && !isUnderTile)
            {
                isCrawl = false;
                velMult = 1f;
                this.GetComponent<CapsuleCollider>().center = new Vector3(0, 8f, 0);
                this.GetComponent<CapsuleCollider>().height = 16f;
            }
        }
    }

    void horizontalMovement()
    {
        velMult = 0;
        if (Mathf.Abs(forwardInput)> inputSetting.inputDelay)
        {
            velMult = 1;
            if (isRun)
            {
                velMult = 3;
            }else if (isCrawl)
            {
                velMult = 0.4f;
            }

            velocity.x = moveSetting.forwardVel * direction*velMult;
            //Debug.Log(velocity.z);
        }
        else
        {
            velocity.x = 0f;
        }

     }

    void Jump()
    {
        if (jumpInput > 0 && Grounded())
        {
            animator.SetBool("Jump", true);

            //play audio
            audioSource.clip = movementAudio[2];
            audioSource.loop = false;
            audioSource.Play();

            if (isRun)
            {
                velocity.y = moveSetting.jumpVel*1.2f;
            }
            else
            {
                velocity.y = moveSetting.jumpVel;
            }
        }else if(jumpInput==0&& Grounded())
        {
            velocity.y = 0;
            animator.SetBool("Jump", false);
        }
        else
        {
            velocity.y -= physSetting.downAccel;
        }
    }

    private void CallAnimation()
    {
        //set animation 
        animator.SetBool("Run", isRun);
        animator.SetBool("Crawl", isCrawl);

        if (!isRun && !isCrawl)
        {
            animator.SetFloat("InputX", forwardInput);
        }

        if (isWin)
        {
            animator.SetBool("isWin", isWin);
        }
    }

    void PlayAudio()
    {
        if (isRun && Grounded())
        {
            audioSource.clip = movementAudio[1];
            audioSource.loop = true;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }else if (isCrawl)
        {
            audioSource.loop = false;
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
        else if (!isCrawl && !isRun && Grounded() && forwardInput != 0)
        {
            audioSource.clip = movementAudio[0];
            audioSource.loop = true;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else if (forwardInput == 0 || (!Grounded() && jumpInput == 0))
        {
            audioSource.loop = false;
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "CrawlTrigger")
        {
            // Debug.Log("Under tile!");
            isUnderTile = true;
        }

        if (other.gameObject.name == "WinTrigger")
        {
            isWin = true;
            Invoke("InvokeWinMenu", 2f);
        }
    }

    void InvokeWinMenu()
    {
        winMenu.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "CrawlTrigger")
        {
            // Debug.Log("Under tile!");
            isUnderTile = false;
        }
    }




}
