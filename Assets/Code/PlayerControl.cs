using UnityEngine;
using System.Collections;
using System;

public class PlayerControl : MonoBehaviour
{
    SpriteComponent sprite;
    Player player;
    GameUnit gameUnit;

    // Use this for initialization
    void Awake()
    {
        sprite = GetComponent<SpriteComponent>();
        player = GetComponent<Player>();
        gameUnit = GetComponent<GameUnit>();
    }

    void FixedUpdate()
    {
        float x = 0;
        float y = 0;

        if( Input.GetAxis( "Horizontal" ) < 0 ) x -= 1f;
        if( Input.GetAxis( "Horizontal" ) > 0 ) x += 1f;
        if( Input.GetAxis( "Vertical" ) < 0 ) y -= 1f;
        if( Input.GetAxis( "Vertical" ) > 0 ) y += 1f;

        //movement.Move( x, y );
        Vector3 force = Vector3.Normalize( new Vector3( x, y, 0f ) );
        force *= gameUnit.combinedWalkSpeed;
        rigidbody.AddForce( force );

        if( x > 0 )
        {
            if( y > 0 )
                sprite.UseWalkAnimation( 0.1f, Direction.TR );
            else
                sprite.UseWalkAnimation( 0.1f, Direction.BR );
        }
        else if( x < 0 )
        {
            if( y > 0 )
                sprite.UseWalkAnimation( 0.1f, Direction.TL );
            else
                sprite.UseWalkAnimation( 0.1f, Direction.BL );
        }
        else
        {
            if( force == Vector3.zero )
                sprite.UseStandAnimation( 0.1f );
            else
                sprite.UseWalkAnimation( 0.1f, sprite.lastDirection );
        }

        if( Input.GetButton( "Fire1" ) )
        {
            player.Attack( sprite.lastDirection );
        }
    }
}
