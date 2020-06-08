using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Vector3 OffsetFromPlayer = new Vector3(0, 2f, -4f);  // 2 up and 4 backward

    public PlayerController Player;

    protected void LateUpdate()
    {
        if (Player == null) return;

        transform.position = Player.transform.position + OffsetFromPlayer;
        transform.LookAt(Player.transform);
    }
}
