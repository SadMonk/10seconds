using UnityEngine;
using System.Collections;

[RequireComponent( typeof( PlayerStats ) )]
public class PlayerControl : MonoBehaviour
{
    PlayerStats stats;

    // Use this for initialization
    void Start()
    {
        stats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKey( KeyCode.LeftArrow ) )
        {
            transform.Translate( new Vector3( -stats.MovementSpeed * Time.deltaTime, 0, 0 ) );
        }

        if( Input.GetKey( KeyCode.RightArrow ) )
        {
            transform.Translate( new Vector3( stats.MovementSpeed * Time.deltaTime, 0, 0 ) );
        }

        if( Input.GetKey( KeyCode.UpArrow ) )
        {
            transform.Translate( new Vector3( 0, stats.MovementSpeed * Time.deltaTime, 0 ) );
        }

        if( Input.GetKey( KeyCode.DownArrow ) )
        {
            transform.Translate( new Vector3( 0, -stats.MovementSpeed * Time.deltaTime, 0 ) );
        }
    }
}
