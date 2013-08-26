using UnityEngine;
using System.Collections;

public class LifeTime : MonoBehaviour {

    float endLifeTime;
    public float lifeTime = 10f;

	// Use this for initialization
	void Start () {
        endLifeTime = Time.time + lifeTime;
	}
	
	// Update is called once per frame
	void Update () {
        if( endLifeTime < Time.time )
            Destroy( gameObject );
	}
}
