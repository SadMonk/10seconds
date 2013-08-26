using UnityEngine;
using System.Collections;

[RequireComponent( typeof( GUIText ) )]
public class WorldText : MonoBehaviour
{
    public GameObject target;

    void Update()
    {
        transform.position = Camera.main.WorldToViewportPoint( target.transform.position );
    }
}
