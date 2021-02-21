using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    public CarContreller CarContreller;
    
    private void OnTriggerEnter(Collider other)
    {
        CarContreller.score += 25f;
        Destroy(this.gameObject);
        Debug.Log("Collider entered 3d"); 
    }
}
