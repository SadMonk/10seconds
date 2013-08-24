using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
		
	private GameUnit gameUnit;
	
	/// <summary>
	/// Picks up buff.
	/// </summary>
	/// <param name='buff'>
	/// The Buff.
	/// </param>
	public void PickUpBuff(Buff buff) {
		gameUnit.AddBuff(buff);
	}
	
	
	// Use this for initialization
	void Start () {		
		
	}
	
	// Update is called once per frame
	void Update () {
				
	}
}
