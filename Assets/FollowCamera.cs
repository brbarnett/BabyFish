using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Vector3 OffsetFromPlayer = new Vector3(-2.5f, 1f, -2.5f);

    public PlayerController Player;

    protected void LateUpdate()
    {
        if (Player == null) return;

        transform.position = Player.transform.position + OffsetFromPlayer;
        transform.LookAt(Player.transform);
    }
}
