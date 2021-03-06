﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Buff
{
    public int bonusStrength = 0;
    public int bonusAttackSpeed = 0;
    public int bonusWalkSpeed = 0;
    public int bonusSkinThickness = 0;
          
    public int chainLightning = 0;
    public int spikes = 0;
    
    public int magnet = 0;
    public int whirlwind = 0; 
    public int trap = 0;
    
    public int bomb= 0;
     
    public float EndTime;
}

public class GameUnit : MonoBehaviour
{       
	public int baseStrength = 0;
	public int baseAttackSpeed = 0;
	public int baseWalkSpeed = 0;
	public int baseSkinThickness = 0;
	
    public int strength = 0;
    public int attackSpeed = 0;
    public int walkSpeed = 0;
    public int skinThickness = 0;    
      
    public int chainLightning = 0;
    public int spikes = 0;
    
    public int magnet = 0;
    public int whirlwind = 0; 
    public int trap = 0; 
    
    public int bomb = 0;
     

    public int hitPoints = 100;

    public int combinedStrength { get { return baseStrength + strength*5; } }
    public float combinedAttackSpeed { get { return (float)( baseAttackSpeed + attackSpeed ) * 0.25f; } }
    public float combinedWalkSpeed { get { return (float)( Mathf.Max((float)(baseWalkSpeed + baseWalkSpeed * walkSpeed * 0.4f) , (float) minimumWalkSpeed) ); } }
    public float combinedSkinThickness {get {return (float)( baseSkinThickness + skinThickness*0.05f);}}

    Queue<Buff> buffs = new Queue<Buff>();
	
    // active buff states
    public bool IsWhirlwindEnabled = false;
    public float WhirlWindEndTime = 0f;
    public bool useMagnet = false;
    
    public int minimumWalkSpeed = 20;

    public GameObject auraPrefab;

	// Update is called once per frame
	void Update ()
    {
        UpdateBuffs();

        if( WhirlWindEndTime < Time.time )
            IsWhirlwindEnabled = false;
	}	

    void UpdateBuffs()
    {
        if( buffs.Count == 0 ) return;
        Buff buff = buffs.Peek();
        if( buff.EndTime > Time.time ) return;

        buffs.Dequeue();
        strength -= buff.bonusStrength;
        attackSpeed -= buff.bonusAttackSpeed;
        walkSpeed -= buff.bonusWalkSpeed;
        skinThickness -= buff.bonusSkinThickness;
        
        chainLightning -= buff.chainLightning;
        spikes -= buff.spikes;
        
        trap -= buff.trap;
        
        bomb -= buff.bomb;
        
        UpdateBuffs();
    }

    public void AddBuff( Buff buff )
    {
        strength += buff.bonusStrength;
        attackSpeed += buff.bonusAttackSpeed;
        walkSpeed += buff.bonusWalkSpeed;
        skinThickness += buff.bonusSkinThickness;
  
        chainLightning += buff.chainLightning;
        spikes += buff.spikes;
        
        magnet += buff.magnet;
        whirlwind += buff.whirlwind;
        trap += buff.trap;
        
        bomb += buff.bomb;

        if(buff.spikes > 0)
        {
            GameObject auraGO = (GameObject)Instantiate( auraPrefab );
            auraGO.GetComponent<Aura>().followTarget = gameObject;
        }
        
        buff.EndTime = Time.time + 10f;
        if( !(buff.whirlwind > 0 || buff.magnet > 0) ) {
            buffs.Enqueue( buff );            
        }
    }
 
    /// <summary>
    /// Receives the damage.
    /// </summary>
    /// <returns>
    /// The actual damage that was dealt.
    /// </returns>
    /// <param name='damage'>
    /// The damage that should be dealt.
    /// </param>
    public int ReceiveDamage( int damage )
    {
        Enemy enemy = GetComponent<Enemy>();
        Player player = GetComponent<Player>();
        Color textColor = ( enemy != null ) ? Color.white : Color.red;

        int actualDamage = (int)Mathf.Round( Mathf.Max( damage * ( 1.20f - (float)skinThickness * 0.1f ), 1f ) );
        hitPoints -= actualDamage;
        Game.Instance.DisplayText( transform, new Vector3( 0, 1.95f, 0f ), new Vector3( 0, 2f ), actualDamage.ToString(), textColor );
        Game.Instance.DisplayText( transform, new Vector3( 0, 2f, -0.001f ), new Vector3( 0, 2f ), actualDamage.ToString(), Color.black );
        if( hitPoints <= 0 )
        {
            if( enemy != null )
                enemy.Kill();
            if( player != null )
                player.Kill();
        }

        return actualDamage;
    }

    void OnDisable()
    {
        if( !gameObject.activeInHierarchy )
            buffs.Clear();
    }
	
}
