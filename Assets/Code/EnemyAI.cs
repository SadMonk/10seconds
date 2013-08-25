using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    SpriteComponent sprite;
    Enemy enemy;

	// Use this for initialization
	void Awake ()
    {
        sprite = GetComponent<SpriteComponent>();
        enemy = GetComponent<Enemy>();
	}

    void FixedUpdate()
    {
        Vector2 currentPos = transform.GetChild( 0 ).position;
        Vector2 targetPos = Game.Instance.player.transform.GetChild( 0 ).position;

        Vector3 distance = targetPos - currentPos;
        distance.Normalize();
        //movement.Move( distance.x, distance.y );

        Vector3 force = distance * enemy.gameUnit.combinedWalkSpeed;
        rigidbody.AddForce( force );
        //Debug.Log( force );

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
	
	// Update is called once per frame
    void Update()
    {

    }
}
