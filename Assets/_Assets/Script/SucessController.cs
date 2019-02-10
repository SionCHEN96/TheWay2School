using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SucessController : MonoBehaviour
{
    public GameObject winMenu;
    // Start is called before the first frame update
    void Start()
    {
        winMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            winMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
