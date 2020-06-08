using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCamera : MonoBehaviour
{
    public Vector3 OffsetFromPlayer = new Vector3(0, -2f, -4f);  // 2 up and 4 backward
    public PlayerController Player;
    public float Sensitivity = 1.0f;

    void Start()
    {
        this.transform.position = this.transform.position + this.OffsetFromPlayer;
    }

    void Update()
    {
        if (this.Player == null) return;

        var rotateHorizontal = Input.GetAxis("Mouse X");
        var rotateVertical = Input.GetAxis("Mouse Y");
        this.transform.RotateAround(this.Player.transform.position, Vector3.up, rotateHorizontal * this.Sensitivity);
        this.transform.RotateAround(this.Player.transform.position, -this.transform.right, rotateVertical * this.Sensitivity);
        this.transform.LookAt(this.Player.transform.position);
    }
}
