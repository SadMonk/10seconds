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

    public void Kill()
    {
        Game.KillCount++;
        dropStuff();
        Destroy( gameObject );
    }

    void dropStuff()
    {
        BuffTypes buffType = (BuffTypes)Random.Range( 0, System.Enum.GetValues( typeof( BuffTypes ) ).Length ); 

        GameObject drop = null;

        switch( buffType )
        {
            case BuffTypes.Strength:
                drop = (GameObject)Resources.Load( "Prefab/Drops/StrengthDropPrefab", typeof( GameObject ) );
                break;
            case BuffTypes.AttackSpeed:
                drop = (GameObject)Resources.Load( "Prefab/Drops/AttackSpeedDropPrefab", typeof( GameObject ) );
                break;
            case BuffTypes.WalkingSpeed:
                drop = (GameObject)Resources.Load( "Prefab/Drops/WalkingSpeedDropPrefab", typeof( GameObject ) );
                break;
            case BuffTypes.SkinThickness:
                drop = (GameObject)Resources.Load( "Prefab/Drops/SkinThicknessDropPrefab", typeof( GameObject ) );
                break;

            case BuffTypes.Spikes:
                drop = (GameObject)Resources.Load( "Prefab/Drops/SpikesDropPrefab", typeof( GameObject ) );
                break;
            case BuffTypes.Magnet:
                drop = (GameObject)Resources.Load( "Prefab/Drops/MagnetDropPrefab", typeof( GameObject ) );
                break;
            case BuffTypes.Whirlwind:
                drop = (GameObject)Resources.Load( "Prefab/Drops/WhirlwindDropPrefab", typeof( GameObject ) );
                break;
            case BuffTypes.NegativeStrength:
                drop = (GameObject)Resources.Load( "Prefab/Drops/NegativeStrengthDropPrefab", typeof( GameObject ) );
                break;
            case BuffTypes.NegativeWalkSpeed:
                drop = (GameObject)Resources.Load( "Prefab/Drops/NegativeWalkSpeedDropPrefab", typeof( GameObject ) );
                break;
            case BuffTypes.NegativeBomb:
                drop = (GameObject)Resources.Load( "Prefab/Drops/NegativeBombDropPrefab", typeof( GameObject ) );
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
                GameUnit playerUnit = Game.Instance.player.GetComponent<GameUnit>();
                int actualDamageDealt = playerUnit.ReceiveDamage( dmg );
                if(playerUnit.spikes > 0) 
                {
                    int reflectedDamage = (int)Mathf.Round(Mathf.Max (1f, actualDamageDealt * playerUnit.spikes* 0.2f));
                    gameUnit.ReceiveDamage(reflectedDamage);
                }
                
                lastAttackTime = Time.time;
            }
        }
    }
}
