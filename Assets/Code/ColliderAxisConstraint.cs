using UnityEngine;
using System.Collections;

public class ColliderAxisConstraint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Vector3 pos = transform.position;
        transform.position = new Vector3( pos.x, pos.y, 0 );
	}
}
