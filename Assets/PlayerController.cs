using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 CenterOfMass = new Vector3(0, 1, 0); // top of the cylinder, center of sphere at the end of the nose
    public float Thrust = 500.0f;

    private Rigidbody _rigidbody;

    void Start()
    {
        this._rigidbody = this.GetComponent<Rigidbody>() ?? throw new Exception("Cannot find rigidbody");

        // manually set center of mass
        this._rigidbody.centerOfMass = this.CenterOfMass;
    }

    void FixedUpdate()
    {
        // get unit vector in the direction of combined keys pressed. ignore if there is no direction (i.e., no keys pressed)
        var direction = this.GetThrustDirection();
        if (direction == Vector3.zero) return;

        // set force to be applied as thrust in the direction of combined keys pressed
        var force = direction * this.Thrust * Time.fixedDeltaTime;

        // center of mass is 1 unit from the origin, which means it's at the center of the sphere at the end of the capsule.
        // the actual force is applied at the nose point by adding an additional 0.5 units to account for the sphere's radius.
        // convert to world coordinates and apply force.
        var forcePoint = this.transform.TransformPoint(this._rigidbody.centerOfMass + new Vector3(0, 0.5f, 0));

        // apply force
        this._rigidbody.AddForceAtPosition(force, forcePoint);
    }

    private Vector3 GetThrustDirection()
    {
        var direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += this.transform.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += this.transform.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += -this.transform.up;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += -this.transform.right;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            direction += this.transform.forward;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            direction += -this.transform.forward;
        }

        return direction.normalized;
    }
}
