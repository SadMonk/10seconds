using UnityEngine;
using System.Collections;

public class SceneChanger : MonoBehaviour {

    public string SceneName;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnMouseDown ()
    {
        if( SceneName == "Exit" )
        {
            Application.Quit();
        }
        else
        {
            Debug.Log( "Switching scene" );
            Application.LoadLevel( SceneName );
        }
	}
}
