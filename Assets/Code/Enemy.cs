using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {

    public GameUnit gameUnit;

    float lastAttackTime;

	// Use this for initialization
	void Awake () {
        gameUnit = GetComponent<GameUnit>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnDestroy()
    {
        if(!Game.isShuttingDown) {
            Game.Instance.KillCount++;
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

    void dropBuff( GameObject dropPrefab )
    {
        Debug.Log( "Enemy Dead. Dropping Buff at:" + transform.GetChild( 0 ).position );
        Game.Instance.SpawnDrop( transform.GetChild( 0 ).position, dropPrefab );
    }

    public void AttackPlayer()
    {
        if( lastAttackTime + ( 1f / gameUnit.combinedAttackSpeed ) < Time.time )
        {
            if( Game.Instance.player != null )
            {
                int dmg = gameUnit.combinedStrength;
                Game.Instance.player.GetComponent<GameUnit>().ReceiveDamage( dmg );
                Game.Instance.DisplayText( Game.Instance.player.transform, new Vector2( 0, 1.95f ), new Vector3( 0, 2f ), gameUnit.combinedStrength.ToString(), Color.red );
                Game.Instance.DisplayText( Game.Instance.player.transform, new Vector2( 0, 2f ), new Vector3( 0, 2f ), gameUnit.combinedStrength.ToString(), Color.black );
                lastAttackTime = Time.time;
            }
        }
    }
}
