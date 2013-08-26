using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor( typeof( ZLevelSorter ) )]
public class EditorZSort : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if( GUILayout.Button( "Sort Now" ) )
        {
            ZLevelSorter sorter = (ZLevelSorter)target;
            Transform transform = sorter.transform;
            transform.position = new Vector3( transform.position.x, transform.position.y, transform.position.y * ZLevelSorter.ZLevelMultiplyer );
        }
    }
}
