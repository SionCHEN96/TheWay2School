using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    private Rigidbody rigidbody;

    float inputX;
    public float speed=2.0f;
    private bool isRun=false;
    private bool isCrawl=false;

    private bool isUnderTile=false;
    

    bool isGrounded = true;


    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");

        //if is run
        if (!isCrawl)
        {
            if (Input.GetKey(KeyCode.LeftShift) && inputX != 0)
            {
                isRun = true;
            }
            else
            {
                isRun = false;
            }
        }

        //if is crawl
        if (!isRun)
        {
            if ((Input.GetKey(KeyCode.LeftControl) && inputX != 0))
            {
                isCrawl = true;
                this.GetComponent<CapsuleCollider>().center = new Vector3(0, 0.5f, 0);
                this.GetComponent<CapsuleCollider>().height = 0.3f;
            }
            else if(!Input.GetKey(KeyCode.LeftControl)&&!isUnderTile)
            {
                isCrawl = false;
                this.GetComponent<CapsuleCollider>().center = new Vector3(0, 1, 0);
                this.GetComponent<CapsuleCollider>().height = 2;
            }
        }

        CallAnimation();

        if (Input.GetButtonDown("Jump") && !isCrawl)
        {
            Jump();
            animator.SetBool("Jump", true);
        }

        Movement();

    }

    private void CallAnimation()
    {
        //set animation 
        animator.SetBool("Run", isRun);
        animator.SetBool("Crawl", isCrawl);

        if (!isRun && !isCrawl)
        {
            animator.SetFloat("InputX", inputX);
        }
    }


    void Jump()
    {
        if (isGrounded == true)
        {
            rigidbody.AddForce(Vector3.up *280.0f);
            isGrounded = false;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        animator.SetBool("Jump", false);
    }


    //control movement direction and speed
    void Movement()
    {
        int dir=1;
        float speedMult=0;

        if (inputX < -0.5f)
        {
            dir = -1;
        }else if (inputX > 0.5f)
        {
            dir = 1;
        }

        if (isRun) { speedMult = 3; }
        else if (isCrawl) { speedMult = 0.5f; }
        else if (inputX>0.5||inputX<-0.5){ speedMult = 1; }


        this.transform.rotation = Quaternion.Euler(0, dir*90, 0);
        this.transform.position += new Vector3(dir*1, 0, 0) * speed * speedMult * Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "CrawlTrigger")
        {
            Debug.Log("Under tile!");
            isUnderTile = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "CrawlTrigger")
        {
            Debug.Log("Under tile!");
            isUnderTile = false;
        }
    }

}
