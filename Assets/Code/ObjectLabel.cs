using UnityEngine;
using System.Collections;

[RequireComponent( typeof( GUIText ) )]
public class ObjectLabel : MonoBehaviour
{

    public Transform target;  // Object that this label should follow
    public Vector3 offset = new Vector3( 0, 3f, 0f );    // Units in world space to offset; 1 unit above object by default
    public Vector3 velocity = Vector3.zero;
    public bool clampToScreen = false;  // If true, label will be visible even if object is off screen
    public float clampBorderSize = 0.05f;  // How much viewport space to leave at the borders when a label is being clamped
    public bool useMainCamera = true;   // Use the camera tagged MainCamera
    public Camera cameraToUse;   // Only use this if useMainCamera is false
    Camera cam;
    Transform camTransform;
    Vector3 lastPosition;

    void Start()
    {
        if( useMainCamera )
            cam = Camera.main;
        else
            cam = cameraToUse;
        camTransform = cam.transform;
    }


    void Update()
    {
        offset += velocity * Time.deltaTime;

        if( target != null )
            lastPosition = target.transform.position;
        else
            Destroy( gameObject );

        if( clampToScreen )
        {
            Vector3 relativePosition = camTransform.InverseTransformPoint( target.position );
            relativePosition.z = Mathf.Max( relativePosition.z, 1.0f );
            transform.position = cam.WorldToViewportPoint( camTransform.TransformPoint( relativePosition + offset ) );
            transform.position = new Vector3( Mathf.Clamp( transform.position.x, clampBorderSize, 1.0f - clampBorderSize ),
                                                Mathf.Clamp( transform.position.y, clampBorderSize, 1.0f - clampBorderSize ),
                                                transform.position.z );
        }
        else
        {
            transform.position = cam.WorldToViewportPoint( lastPosition + offset );
        }
    }
}