using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(MovementComponent))]
public class PlayerControl : MonoBehaviour
{
    MovementComponent movement;

    // Use this for initialization
    void Start()
    {
        movement = GetComponent<MovementComponent>();
    }

    void FixedUpdate()
    {
        movement.Move(
            -Convert.ToSingle( Input.GetKey( KeyCode.LeftArrow ) ) + Convert.ToSingle( Input.GetKey( KeyCode.RightArrow ) ),
            -Convert.ToSingle( Input.GetKey( KeyCode.DownArrow ) ) + Convert.ToSingle( Input.GetKey( KeyCode.UpArrow ) ) );
    }
}
