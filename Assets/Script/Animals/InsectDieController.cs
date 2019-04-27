using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectDieController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject insect;
    public GameObject insectTrigger;
    Animator insectAnimator;
    bool isDead;

    void Start()
    {
        isDead = false;
        insect = transform.parent.gameObject;
        insectAnimator = insect.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;

            //set insect DeathTrigger to false
            insectTrigger.SetActive(false);

            insect.GetComponent<LeftRight>().state = 0;
            Invoke("InsectDie", 2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isDead)
        {
            if (other.CompareTag("Player"))
            {
                isDead = true;
                InvokeAni();
            }
        }
    }

    void InsectDie()
    {
        insect.SetActive(false);
    }

    void InvokeAni()
    {
        insectAnimator.SetBool("Die", isDead);
    }
}
