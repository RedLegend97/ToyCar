using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFuel : MonoBehaviour
{
    public CarContreller CarContreller;
    
    private void OnTriggerEnter(Collider other)
    {
        CarContreller.fuel = 1f;
        Destroy(this.gameObject);
        Debug.Log("Collider entered 3d"); 
    }
}