using UnityEngine;
using System.Collections;

public class MovementComponent : MonoBehaviour
{
    public float MovementSpeed;
    public Vector3 Velocity;

    public const float ZLevelMultiplyer = 0.001f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
    void FixedUpdate()
    {
        float y = transform.position.y;
        Transform child = transform.GetChild( 0 );
        if( child != null )
            y = child.position.y;
        transform.position = new Vector3( transform.position.x, transform.position.y, y * ZLevelMultiplyer );
    }
}
