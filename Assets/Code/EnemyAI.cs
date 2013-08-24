using UnityEngine;
using System.Collections;

[RequireComponent( typeof( MovementComponent ) )]
public class EnemyAI : MonoBehaviour
{
    MovementComponent movement;

	// Use this for initialization
	void Start ()
    {
        movement = GetComponent<MovementComponent>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 currentPos = transform.position;
        Vector2 targetPos = Game.Instance.player.transform.position;

        Vector2 distance = targetPos - currentPos;
        distance.Normalize();
        movement.Move( distance.x, distance.y );
	}
}
