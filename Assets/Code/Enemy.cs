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
        Debug.Log("Disabled?");
        if( !gameObject.activeInHierarchy )
        {  
            Debug.Log("inactive!");
            dropStuff();
        }
    }
    
    void dropStuff()
    {
        // initialize base buff values
        int bonusStrength = 0;
        int bonusAttackSpeed = 0;
        int bonusWalkSpeed = 0;
        int bonusDodgeChance = 0;
        int bonusSkinThickness = 0;
        
        int buffType = Random.Range(0,5); // we want a number between 0 and 4 
        
        GameObject drop = null;
        
        
        switch(buffType) 
        {
            case (int)BuffTypes.Strength:
                drop = (GameObject)Resources.Load( "Prefab/StrengthDropPrefab", typeof( GameObject ) );                
                break;
            case (int)BuffTypes.AttackSpeed:
                drop = (GameObject)Resources.Load( "Prefab/AttackSpeedDropPrefab", typeof( GameObject ) );
                break;
            case (int)BuffTypes.WalkingSpeed:
                drop = (GameObject)Resources.Load( "Prefab/WalkinSpeedDropPrefab", typeof( GameObject ) );
                break;
            case (int)BuffTypes.Dodge:
                drop = (GameObject)Resources.Load( "Prefab/DodgeDropPrefab", typeof( GameObject ) );
                break;
            case (int)BuffTypes.SkinThickness:
                drop = (GameObject)Resources.Load( "Prefab/SkinThicknessDropPrefab", typeof( GameObject ) );
                break;
            default:
                Debug.Log("Default case.. dafuq??");
                break;
        }
        if(drop != null) {
            dropBuff(drop);
        }
    }
    
    void dropBuff(GameObject dropPrefab)
    {
        Debug.Log("Enemy Dead. Dropping Buff at:" + transform.GetChild( 0 ).position);
        Game.Instance.SpawnDrop(transform.GetChild( 0 ).position,dropPrefab);
    }
}
