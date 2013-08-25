using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {

    public GameUnit gameUnit;

	// Use this for initialization
	void Awake () {
        gameUnit = GetComponent<GameUnit>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnDisable()
    {
        if( !gameObject.activeInHierarchy )
            dropStuff();
    }
    
    void dropStuff()
    {
        // initialize base buff values
        int bonusStrength = 0;
        int bonusAttackSpeed = 0;
        int bonusWalkSpeed = 0;
        int bonusDodgeChance = 0;
        int bonusSkinThickness = 0;
        
        int buffType = Random.Range(0,4); // we want a number between 0 and 4 
        
        
        
        switch(buffType) 
        {
            case (int)BuffTypes.Strength:
                bonusStrength = 1;
                break;
            case (int)BuffTypes.AttackSpeed:
                bonusAttackSpeed = 1;
                break;
            case (int)BuffTypes.WalkingSpeed:
                bonusWalkSpeed = 1;
                break;
            case (int)BuffTypes.Dodge:
                bonusDodgeChance = 1;
                break;
            case (int)BuffTypes.SkinThickness:
                bonusSkinThickness = 1;
                break;
            default:
                break;
            
            
        }
        
        

        
    }
}
