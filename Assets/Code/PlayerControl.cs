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

    }

    void Update()
    {
        Direction direction = sprite.lastDirection;
        float animationSpeed = 0.1f;

        float x = 0;
        float y = 0;

        if( Input.GetAxis( "Horizontal" ) < 0 ) x -= 1f;
        if( Input.GetAxis( "Horizontal" ) > 0 ) x += 1f;
        if( Input.GetAxis( "Vertical" ) < 0 ) y -= 1f;
        if( Input.GetAxis( "Vertical" ) > 0 ) y += 1f;

        //movement.Move( x, y );
        Vector3 force = Vector3.Normalize( new Vector3( x, y, 0f ) );

        if( x > 0 )
        {
            if( y > 0 )
                direction = Direction.TR;
            else
                direction = Direction.BR;
        }
        else if( x < 0 )
        {
            if( y > 0 )
                direction = Direction.TL;
            else
                direction = Direction.BL;
        }
        else
        {
            if( y > 0 )
                direction = Direction.TR;
            else if( y < 0 )
                direction = Direction.BL;
        }

        if( Input.GetButtonDown( "Fire1" ) )
        {
            if( player.Attack( direction ) )
            {
                sprite.UseAttackAnimation( 0.2f, direction );
            }
        }


        if( force != Vector3.zero )
            sprite.UseWalkAnimation( animationSpeed, direction );
        else
            sprite.UseStandAnimation( animationSpeed );
    }
}
