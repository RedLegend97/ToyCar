using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessFail : MonoBehaviour
{
    public GameObject deathMenu;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerTop")
        {
            StartCoroutine("OpenMenu");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerTop")
        {
            StartCoroutine("OpenMenu");
        }
    }

    IEnumerator OpenMenu()
    {
        yield return new WaitForSeconds(1);
        deathMenu.SetActive(true);
    }
}