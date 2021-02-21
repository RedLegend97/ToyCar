using System.Collections;
using System.Collections.Generic;
using FarseerPhysics.Dynamics.Joints;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using UnityEngine;

public class WheelJointComponent : FSJointComponent
{
    protected WheelJoint joint;

    //Joint properties
    [SerializeField] public Vector2 axis = Vector2.up;
    public bool MotorEnabled = false;
    public float MaxMotorTorque = 400f;
    public float MotorSpeed = 0f;
    public float springDampingRatio = 5f;
    public float springFrequency = 5f;
    public Vector2 LocalAnchorB = Vector2.zero;


    public override void InitJoint()
    {
        base.InitJoint();
        //B tekerlek
        //A araba
        //jesus %99 em-in
        Vector3 p0 = BodyB.transform.TransformPoint(new Vector3(LocalAnchorB.x, LocalAnchorB.y, -5f));

        joint = JointFactory.CreateWheelJoint(FSWorldComponent.PhysicsWorld,
            BodyA.PhysicsBody,
            BodyB.PhysicsBody,
            BodyB.PhysicsBody.GetLocalPoint(FSHelper.Vector3ToFVector2(p0)),
            FSHelper.Vector2ToFVector2(axis));
        //UnitY ile yanlış yapıyor olabilirim


        joint.MaxMotorTorque = MaxMotorTorque;
        joint.MotorEnabled = MotorEnabled;
        joint.MotorSpeed = MotorSpeed;


        joint.SpringDampingRatio = springDampingRatio;
        joint.SpringFrequencyHz = springFrequency;

        joint.CollideConnected = false;


        //
    }

    public override void Update()
    {
        base.Update();
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        if (BodyA == null || BodyB == null)
            return;
        // get draw point
        Vector3 p0 = BodyB.transform.TransformPoint(new Vector3(LocalAnchorB.x, LocalAnchorB.y, -5f));
        //Vector3 p0 = FSHelper.LocalTranslatedVec3(new Vector3(LocalAnchorB.x, LocalAnchorB.y, -5f), BodyB.transform);
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(p0, 0.1f);
    }
}