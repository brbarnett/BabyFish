using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    void Start()
    {
        this._rigidbody = this.GetComponent<Rigidbody>() ?? throw new Exception("Cannot find rigidbody");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            print("W key was pressed");
        }
    }
}
