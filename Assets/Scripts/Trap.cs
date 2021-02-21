using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject deathMenu;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Collision happened with trap player is the toucher");
            StartCoroutine("OpenMenu");
        }


        //DeathMenu
    }
    
    IEnumerator OpenMenu()
    {
        yield return new WaitForSeconds(1);
        Instantiate(deathMenu);
    }
}