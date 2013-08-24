using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public GameUnit gameUnit;

	// Use this for initialization
	void Awake () {
        gameUnit = GetComponent<GameUnit>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
