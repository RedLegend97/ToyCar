using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Wall : MonoBehaviour
{

    public GameObject deathMenu;
    //TODO SHOOT TO BREAK WALLS 
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collision happened with wall");
        if (other.tag == "Bullet")
        {
            Debug.Log("Bullet hit me!");
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }

        if (other.tag == "Player")
        {
            Debug.Log("Player touch the wall");
            StartCoroutine("OpenMenu");
        }
    }
    
     IEnumerator OpenMenu()
     {
         yield return new WaitForSeconds(1);
         Instantiate(deathMenu);
     }
}