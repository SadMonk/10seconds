using UnityEngine;
using System.Collections;

[RequireComponent( typeof( PlayerStats ) )]
public class PlayerControl : MonoBehaviour
{
    PlayerStats stats;

    // Use this for initialization
    void Start()
    {
        stats = GetComponent<PlayerStats>();
    }

    void FixedUpdate()
    {
        float velX = 0;
        float velY = 0;

        if( Input.GetKey( KeyCode.LeftArrow ) )
        {
            velX -= stats.MovementSpeed;
        }

        if( Input.GetKey( KeyCode.RightArrow ) )
        {
            velX += stats.MovementSpeed;
        }

        if( Input.GetKey( KeyCode.UpArrow ) )
        {
            velY += stats.MovementSpeed;
        }

        if( Input.GetKey( KeyCode.DownArrow ) )
        {
            velY -= stats.MovementSpeed;
        }

        rigidbody.velocity = new Vector3( velX, velY, 0f );

    }
}
