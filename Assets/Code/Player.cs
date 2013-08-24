using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
		
	public int strength = 0;
	public int attackSpeed = 0;
	public int walkSpeed = 0;
	public int dodgeChance = 0;
	public int skinThickness = 0;
	
	private Dictionary<string,List<Buff>> buffs;
	
	public void PickUpBuff(Buff buff) {
		string buffType = buff.getType();
		if(!buffs.ContainsKey(buffType)) {
			buffs[buffType] = new List<Buff>();
		}
		buffs[buffType].Add(buff);
	}
	
	
	// Use this for initialization
	void Start () {		
		
	}
	
	// Update is called once per frame
	void Update () {
				
	}
}
