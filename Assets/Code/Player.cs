using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent( typeof( GameUnit ) )]
public class Player : MonoBehaviour
{
    public GameUnit gameUnit;

    float lastAttackTime = 0f;
    
    float lastBombHurtTime = 0f;

    /// <summary>
    /// Picks up buff.
    /// </summary>
    /// <param name='buff'>
    /// The Buff.
    /// </param>
    public void PickUpBuff( Buff buff )
    {
        gameUnit.AddBuff( buff );
    }


    // Use this for initialization
    void Start()
    {
        gameUnit = GetComponent<GameUnit>();

        gameUnit.baseStrength += Game.SkillDamage;
        gameUnit.hitPoints += Game.SkillLife;
    }

    // Update is called once per frame
    void Update()
    {
		CheckForDrop();	
        CheckForBombHurt();
    }

    public bool Attack( Direction direction )
    {
        if( lastAttackTime + ( 1f / gameUnit.combinedAttackSpeed ) < Time.time )
        {
            
            Vector3 hitLocation = transform.GetChild( 0 ).position;
            float radius = 4f;

            switch( direction )
            {
                case Direction.TR: hitLocation += new Vector3( radius * 0.66f, radius * 0.66f, 0f ); break;
                case Direction.BR: hitLocation += new Vector3( radius * 0.66f, -radius * 0.66f, 0f ); break;
                case Direction.BL: hitLocation += new Vector3( -radius * 0.66f, -radius * 0.66f, 0f ); break;
                case Direction.TL: hitLocation += new Vector3( -radius * 0.66f, radius * 0.66f, 0f ); break;
                case Direction.ALL: hitLocation += Vector3.zero; radius *= 2f; break;
            }

            var colliders = Physics.OverlapSphere( hitLocation, radius );
            
            bool weHitSomething = false;
            
            foreach( var collider in colliders )
            {
                var go = collider.transform.parent.gameObject;
                if( go != null && go != this.gameObject )
                {
                    Enemy enemy = go.GetComponent<Enemy>();
                    if( enemy != null )
                    {
                        weHitSomething = true;
                        int dmg = Mathf.Max(1,gameUnit.combinedStrength);
                        Vector3 directionToEnemy = Vector3.Normalize( enemy.transform.GetChild( 0 ).position - transform.GetChild( 0 ).position );
                        enemy.GetComponent<GameUnit>().ReceiveDamage( dmg );
                        enemy.rigidbody.AddForce( directionToEnemy * 2500f );
                    }
                }
            }
            if(weHitSomething)
            {
                AudioSource hitsound = (AudioSource)gameObject.GetComponent<AudioSource>();
                hitsound.Play();
            }
            lastAttackTime = Time.time;
            return true;
        }
        else
        {
            return false;
        }
    }
	
	/// <summary>
	/// Checks for a nearby drop and - if found - picks it up.
	/// </summary>
	private void CheckForDrop()
	{		
		Vector3 hitLocation = transform.GetChild( 0 ).position;
		float radius = 2f;
        if(gameUnit.useMagnet) 
        {
            radius = 12f;
            gameUnit.useMagnet = false;
        }
		var colliders = Physics.OverlapSphere( hitLocation, radius );
		
        foreach( var collider in colliders )
        {
            var go = collider.transform.parent.gameObject;
            if( go != null && go != this.gameObject )
            {
                Drop drop = go.GetComponent<Drop>();
                if( drop != null )
                {
                    // build a buff and pick it up.
                    Buff buff = new Buff();
                    buff.bonusAttackSpeed = drop.bonusAttackSpeed;
                    buff.bonusSkinThickness = drop.bonusSkinThickness;
                    buff.bonusStrength = drop.bonusStrength;
                    buff.bonusWalkSpeed = drop.bonusWalkSpeed;
                    
                    buff.chainLightning = drop.chainLightning;
                    buff.trap = drop.trap;
                    
                    buff.magnet = drop.magnet;
                    buff.whirlwind = drop.whirlwind;  
                    
                    buff.bomb = drop.bomb;
                    
					this.PickUpBuff(buff);					
                    Destroy(go);
                }
            }
        }
	}
	

    void OnDestroy()
    {
        if( !Game.isShuttingDown )
        {
            Application.LoadLevel( "GameOver" );
        }
    }
    
    void CheckForBombHurt() 
    {
        float currentSecond = Mathf.Ceil(Time.time);
        if(currentSecond > lastBombHurtTime) {
            lastBombHurtTime = currentSecond;
            if(gameUnit.bomb > 0)
            {
                gameUnit.ReceiveDamage(gameUnit.bomb);
            }
        }
    }
}
