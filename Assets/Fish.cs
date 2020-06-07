using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private Rigidbody _rigidBody;

    void Start()
    {
        this._rigidBody = this.GetComponent<Rigidbody>() ?? throw new Exception("Cannot find rigidbody");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            var direction = this._rigidBody.transform.position - transform.position;
            this._rigidBody.AddForceAtPosition(direction.normalized, transform.position);
        }
    }
}
