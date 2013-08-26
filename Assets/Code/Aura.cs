using UnityEngine;
using System.Collections;

public class Aura : MonoBehaviour
{
    public GameObject followTarget;
    public Vector3 Offset;

    float deathTime;

    // Use this for initialization
    void Start()
    {
        deathTime = Time.time + 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if( followTarget == null )
            Destroy( gameObject );

        if( deathTime < Time.time )
            Destroy( gameObject );

        transform.position = followTarget.transform.position + Offset;
    }
}
