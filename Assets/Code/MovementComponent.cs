using UnityEngine;
using System.Collections;

public class MovementComponent : MonoBehaviour
{
    public float MovementSpeed;
    public Vector3 Velocity;

    public const float ZLevelMultiplyer = 0.001f;

    SpriteComponent sprite;

	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteComponent>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        rigidbody.velocity = Velocity * MovementSpeed;
        transform.position = new Vector3( transform.position.x, transform.position.y, transform.position.y * ZLevelMultiplyer );
	}

    public void Move( float x, float y )
    {
        Velocity = new Vector3( x, y, 0 );
        Velocity.Normalize();

        if( Velocity.x > 0f && Velocity.y > 0f ) sprite.UseWalkAnimation( 0.1f, Direction.TR );
        if( Velocity.x > 0f && Velocity.y < 0f ) sprite.UseWalkAnimation( 0.1f, Direction.BR );
        if( Velocity.x < 0f && Velocity.y < 0f ) sprite.UseWalkAnimation( 0.1f, Direction.BL );
        if( Velocity.x < 0f && Velocity.y > 0f ) sprite.UseWalkAnimation( 0.1f, Direction.TL );
    }
}
