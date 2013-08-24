using UnityEngine;
using System.Collections;

public class MovementComponent : MonoBehaviour
{
    public float MovementSpeed;
    public Vector3 Velocity;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        rigidbody.velocity = Velocity * MovementSpeed;
	}

    public void Move( float x, float y )
    {
        Velocity = new Vector3( x, y, 0 );
        Velocity.Normalize();
    }
}
