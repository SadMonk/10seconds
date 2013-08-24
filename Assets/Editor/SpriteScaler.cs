using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor( typeof( SpriteComponent ) )]
public class SpriteScaler : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if( GUILayout.Button( "Set Size" ) )
        {
            SpriteComponent component = (SpriteComponent)target;
            component.UpdateSize();
        }
    }
}
