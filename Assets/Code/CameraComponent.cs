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

    void Update()
    {
        camera.orthographicSize = (float)Screen.height / (float)UnitSize / 2.0f;
    }

    public Vector3 Project( Vector3 screenPosition ) { return camera.ScreenPointToRay( screenPosition ).origin; }
    public Vector3 Project() { return Project( Input.mousePosition ); }
}
