using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailOnFlip : MonoBehaviour
{
    public GameObject deathMenu;

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine("OpenMenu");
        Debug.Log("Fail on flip should trigger");
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine("OpenMenu");
        Debug.Log("Fail on flip should trigger");

    }

    IEnumerator OpenMenu()
    {
        yield return new WaitForSeconds(1);
        deathMenu.SetActive(true);
    }
}