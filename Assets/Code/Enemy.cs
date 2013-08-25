using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{

    public GameUnit gameUnit;

    float lastAttackTime;

    // Use this for initialization
    void Awake()
    {
        gameUnit = GetComponent<GameUnit>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDestroy()
    {
        if( !Game.isShuttingDown )
        {
            Game.Instance.KillCount++;
            dropStuff();
        }
    }

    void dropStuff()
    {
        BuffTypes buffType = (BuffTypes)Random.Range( 0, System.Enum.GetValues( typeof( BuffTypes ) ).Length ); 

        GameObject drop = null;

        switch( buffType )
        {
            case BuffTypes.Strength:
                drop = (GameObject)Resources.Load( "Prefab/StrengthDropPrefab", typeof( GameObject ) );
                break;
            case BuffTypes.AttackSpeed:
                drop = (GameObject)Resources.Load( "Prefab/AttackSpeedDropPrefab", typeof( GameObject ) );
                break;
            case BuffTypes.WalkingSpeed:
                drop = (GameObject)Resources.Load( "Prefab/WalkingSpeedDropPrefab", typeof( GameObject ) );
                break;
            case BuffTypes.SkinThickness:
                drop = (GameObject)Resources.Load( "Prefab/SkinThicknessDropPrefab", typeof( GameObject ) );
                break;

            case BuffTypes.ChainLightning:
                drop = (GameObject)Resources.Load( "Prefab/ChainLightningDropPrefab", typeof( GameObject ) );
                break;
            case BuffTypes.Trap:
                drop = (GameObject)Resources.Load( "Prefab/TrapDropPrefab", typeof( GameObject ) );
                break;
            case BuffTypes.Spikes:
                drop = (GameObject)Resources.Load( "Prefab/SpikesDropPrefab", typeof( GameObject ) );
                break;
            case BuffTypes.Magnet:
                drop = (GameObject)Resources.Load( "Prefab/MagnetDropPrefab", typeof( GameObject ) );
                break;
            case BuffTypes.Whirlwind:
                drop = (GameObject)Resources.Load( "Prefab/WhirlwindDropPrefab", typeof( GameObject ) );
                break;
            case BuffTypes.NegativeStrength:
                drop = (GameObject)Resources.Load( "Prefab/NegativeStrengthDropPrefab", typeof( GameObject ) );
                break;
            case BuffTypes.NegativeWalkSpeed:
                drop = (GameObject)Resources.Load( "Prefab/NegativeWalkSpeedDropPrefab", typeof( GameObject ) );
                break;
            case BuffTypes.NegativeBomb:
                drop = (GameObject)Resources.Load( "Prefab/NegativeBombDropPrefab", typeof( GameObject ) );
                break;

            default:
                Debug.Log( "Default case.. dafuq??" );
                break;
        }
        if( drop != null )
        {
            dropBuff( drop );
        }
    }

    void dropBuff( GameObject dropPrefab )
    {
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
                lastAttackTime = Time.time;
            }
        }
    }
}
