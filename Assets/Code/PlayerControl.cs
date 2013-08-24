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
        float x = 0;
        float y = 0;

        if( Input.GetKey( KeyCode.LeftArrow ) ) x -= 1f;
        if( Input.GetKey( KeyCode.RightArrow ) ) x += 1f;
        if( Input.GetKey( KeyCode.DownArrow ) ) y -= 1f;
        if( Input.GetKey( KeyCode.UpArrow ) ) y += 1f;

        movement.Move( x, y );
    }
}
