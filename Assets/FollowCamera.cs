using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Vector3 OffsetFromPlayer = new Vector3(0, 2f, -4f);  // 2 up and 4 backward
    public PlayerController Player;

    protected void LateUpdate()
    {
        if (this.Player == null) return;

        this.transform.position = this.Player.transform.position + this.OffsetFromPlayer;
        this.transform.LookAt(this.Player.transform);
    }
}
