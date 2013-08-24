using UnityEngine;
using System.Collections;
using System;

[RequireComponent( typeof( Camera ) )]
public class CameraComponent : MonoBehaviour
{
    /// <summary>
    /// Size of a game space unit in pixels
    /// </summary>
    public int UnitSize;
    public GameObject FollowTarget;

    void Update()
    {
        camera.orthographicSize = (float)Screen.height / (float)UnitSize / 2.0f;

        if( FollowTarget != null )
            transform.position = new Vector3( FollowTarget.transform.position.x, FollowTarget.transform.position.y, transform.position.z );
    }

    public Vector3 Project( Vector3 screenPosition ) { return camera.ScreenPointToRay( screenPosition ).origin; }
    public Vector3 Project() { return Project( Input.mousePosition ); }
}
