using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor( typeof( StaticSprite ) )]
public class SpriteScaler : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if( GUILayout.Button( "Set Size" ) )
        {
            StaticSprite component = (StaticSprite)target;
            component.UpdateSize();
        }
    }
}
