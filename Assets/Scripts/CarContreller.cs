using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Microsoft.Xna.Framework;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class CarContreller : MonoBehaviour
{
    [FormerlySerializedAs("image")] public UnityEngine.UI.Image batteryRem;
    public GameObject deathMenu;

    public float fuel = 1;
    public float fuelConsumption = 0.1f;
    public FSRevoluteJointComponent backTire;
    public FSRevoluteJointComponent frontTire;
    public FSBodyComponent backBody;
    public FSBodyComponent frontBody;
    public FSBodyComponent car;

    public float score = 0f;

    public float speed = 20f;
    public Vector2 jumpForce = new Vector2(0, 10f);
    public float jumpPow = 1;

    public Vector2 LocalAnchorB = Vector2.zero;
    private float movement;
    public float rotationPow = 1f;


    // Update is called once per frame
    private void Update()
    {
        movement = Input.GetAxis("Horizontal");
        batteryRem.fillAmount = fuel;
    }

    private void FixedUpdate()
    {
        if (fuel > 0)
        {
            Vector3 p0 = car.transform.TransformPoint(new Vector3(LocalAnchorB.x, LocalAnchorB.y, -5f));
            backBody.PhysicsBody.ApplyTorque(-movement * speed * Time.fixedDeltaTime);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                car.PhysicsBody.ApplyForce(jumpPow * FSHelper.Vector2ToFVector2(jumpForce),
                    FSHelper.Vector3ToFVector2(p0));
            }
        }
        else
        {
            StartCoroutine("OpenMenu");
        }

        fuel -= fuelConsumption * Mathf.Abs(movement) * Time.fixedDeltaTime;

        if (Input.GetKey(KeyCode.K))
        {
            car.PhysicsBody.ApplyTorque(-rotationPow * speed * Time.fixedDeltaTime);
        }

        if (Input.GetKey(KeyCode.J))
        {
            car.PhysicsBody.ApplyTorque(rotationPow * speed * Time.fixedDeltaTime);
        }

        if (fuel <= 0)
        {
            Debug.Log("You have failed");
        }
    }

    public void OnDrawGizmos()
    {
        Vector3 p0 = car.transform.TransformPoint(new Vector3(LocalAnchorB.x, LocalAnchorB.y, -5f));
        //Vector3 p0 = FSHelper.LocalTranslatedVec3(new Vector3(LocalAnchorB.x, LocalAnchorB.y, -5f), BodyB.transform);
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(p0, 0.1f);
    }

    
    IEnumerator OpenMenu()
    {
        yield return new WaitForSeconds(1);
        Instantiate(deathMenu);
        deathMenu.SetActive(true);
    }
    //Add score with the time spent on the ground
}