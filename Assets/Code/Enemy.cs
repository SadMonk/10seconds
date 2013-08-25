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
        int buffType = Random.Range(0,21); // we want a number between 0 and 4 
        
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
            
            case (int)BuffTypes.ChainLightning:
                drop = (GameObject)Resources.Load( "Prefab/ChainLightningDropPrefab", typeof( GameObject ) );
                break;
            case (int)BuffTypes.FlameThrower:
                drop = (GameObject)Resources.Load( "Prefab/FlameThrowerDropPrefab", typeof( GameObject ) );
                break;
            case (int)BuffTypes.Explosion:
                drop = (GameObject)Resources.Load( "Prefab/ExplosionDropPrefab", typeof( GameObject ) );
                break;
            case (int)BuffTypes.Spikes:
                drop = (GameObject)Resources.Load( "Prefab/SpikesDropPrefab", typeof( GameObject ) );
                break;
            case (int)BuffTypes.Chainsaw:
                drop = (GameObject)Resources.Load( "Prefab/ChainsawDropPrefab", typeof( GameObject ) );
                break;
            case (int)BuffTypes.Magnet:
                drop = (GameObject)Resources.Load( "Prefab/MagnetDropPrefab", typeof( GameObject ) );
                break;
            case (int)BuffTypes.Whirlwind:
                drop = (GameObject)Resources.Load( "Prefab/WhirlwindDropPrefab", typeof( GameObject ) );
                break;
            case (int)BuffTypes.BonusDmgVsOrcs:
                drop = (GameObject)Resources.Load( "Prefab/BonusDmgVsOrcsDropPrefab", typeof( GameObject ) );
                break;
            case (int)BuffTypes.BonusDmgVsGoblins:
                drop = (GameObject)Resources.Load( "Prefab/BonusDmgVsGoblinsDropPrefab", typeof( GameObject ) );
                break;
            case (int)BuffTypes.NegativeStrength:
                drop = (GameObject)Resources.Load( "Prefab/NegativeStrengthDropPrefab", typeof( GameObject ) );
                break;
            case (int)BuffTypes.NegativeAttackSpeed:
                drop = (GameObject)Resources.Load( "Prefab/NegativeAttackSpeedDropPrefab", typeof( GameObject ) );
                break;
            case (int)BuffTypes.NegativeWalkSpeed:
                drop = (GameObject)Resources.Load( "Prefab/NegativeWalkSpeedDropPrefab", typeof( GameObject ) );
                break;
            case (int)BuffTypes.NegativeDodge:
                drop = (GameObject)Resources.Load( "Prefab/NegativeDodgeDropPrefab", typeof( GameObject ) );
                break;
            case (int)BuffTypes.NegativeSkinThickness:
                drop = (GameObject)Resources.Load( "Prefab/NegativeSkinThicknessDropPrefab", typeof( GameObject ) );
                break;
            case (int)BuffTypes.NegativeBomb:
                drop = (GameObject)Resources.Load( "Prefab/NegativeBombDropPrefab", typeof( GameObject ) );
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
                Game.Instance.DisplayText( Game.Instance.player.transform, new Vector2( 0, 1.95f ), new Vector2( 0, 2f ), gameUnit.combinedStrength.ToString(), Color.red );
                Game.Instance.DisplayText( Game.Instance.player.transform, new Vector2( 0, 2f ), new Vector2( 0, 2f ), gameUnit.combinedStrength.ToString(), Color.black );
                lastAttackTime = Time.time;
            }
        }
    }
}
