using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameObject finishCongrats;
    
    private void OnTriggerEnter(Collider other)
    {
        finishCongrats.SetActive(true);
        Time.timeScale = 0.1f;
    }
}
