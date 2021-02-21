using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private Transform bulletExitPos;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            var cbullet = Instantiate(bullet, bulletExitPos.transform.position, Quaternion.identity);
            cbullet.GetComponent<Rigidbody>().AddForce(new Vector3(bulletSpeed, 0, 0));
        }
    }
}