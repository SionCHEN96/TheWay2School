using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{

    public float speed = 2.0f;
    public float jumpPower = 280.0f;

    public AudioClip[] movementAudio;

    private Animator animator;
    private Rigidbody rigidbody;

    float inputX;
    private bool isRun = false;
    private bool isCrawl = false;
    private bool isUnderTile = false;
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
        //isGrounded = CheckGound();

        if (isGrounded)
        {
            GetRun();
            GetCrawl();

            if (Input.GetButton("Jump"))
            {
                animator.SetBool("Jump", true);
                if (isRun)
                {
                    rigidbody.AddForce(Vector3.up * jumpPower*1.2f);
                }
                else
                {
                    rigidbody.AddForce(Vector3.up * jumpPower);
                }
                isGrounded = false;
            }
            else
            {
                animator.SetBool("Jump", false);
                if (inputX != 0)
                {
                    animator.SetBool("Run", true);
                }
            }
        }

        Movement();
        CallAnimation();

    }

    void GetRun()
    {
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
    }

    void GetCrawl()
    {
        //if is crawl
        if (!isRun)
        {
            if ((Input.GetKey(KeyCode.LeftControl) && (inputX != 0)))
            {
                isCrawl = true;
                this.GetComponent<CapsuleCollider>().center = new Vector3(0, 4f, 0);
                this.GetComponent<CapsuleCollider>().height = 9f;
            }
            else if (!Input.GetKey(KeyCode.LeftControl) && !isUnderTile)
            {
                isCrawl = false;
                this.GetComponent<CapsuleCollider>().center = new Vector3(0, 8f, 0);
                this.GetComponent<CapsuleCollider>().height = 16f;
            }
        }
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



    //control movement direction and speed
    void Movement()
    {
        int dir = 1;
        float speedMult = 0;

        if (inputX < -0.5f)
        {
            dir = -1;
        }
        else if (inputX > 0.5f)
        {
            dir = 1;
        }

        if (isRun)
        {
            speedMult = 3;

        }
        else if (isCrawl)
        {
            speedMult = 0.4f;
        }
        else if (inputX > 0.5 || inputX < -0.5)
        {
            speedMult = 1;
        }

        if (!isGrounded)
        {
            speedMult *= 0.5f;
        }else if (!isGrounded&&isRun)
        {
            speedMult *= 3f;
        }



        this.transform.rotation = Quaternion.Euler(0, dir * 90, 0);
        this.transform.position += new Vector3(dir * 1, 0, 0) * speed * speedMult * Time.deltaTime;
       // rigidbody.AddForce(new Vector3(dir * 1, 0, 0)*2000f);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "CrawlTrigger")
        {
            // Debug.Log("Under tile!");
            isUnderTile = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "CrawlTrigger")
        {
            // Debug.Log("Under tile!");
            isUnderTile = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
        {
            isGrounded = true;
        }
    }


}
