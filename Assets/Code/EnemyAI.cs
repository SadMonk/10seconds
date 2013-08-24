using UnityEngine;
using System.Collections;

[RequireComponent( typeof( MovementComponent ) )]
public class EnemyAI : MonoBehaviour
{
    MovementComponent movement;
    SpriteComponent sprite;

	// Use this for initialization
	void Start ()
    {
        movement = GetComponent<MovementComponent>();
        sprite = GetComponent<SpriteComponent>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 currentPos = transform.position;
        Vector2 targetPos = Game.Instance.player.transform.position;

        Vector2 distance = targetPos - currentPos;
        distance.Normalize();
        movement.Move( distance.x, distance.y );

        if( distance.x > 0 )
        {
            if( distance.y > 0 )
                sprite.UseWalkAnimation( 0.1f, Direction.TR );
            else
                sprite.UseWalkAnimation( 0.1f, Direction.BR );
        }
        else
        {
            if( distance.y > 0 )
                sprite.UseWalkAnimation( 0.1f, Direction.TL );
            else
                sprite.UseWalkAnimation( 0.1f, Direction.BL );
        }
	}
}
