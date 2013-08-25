using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Buff
{
    public int bonusStrength = 0;
    public int bonusAttackSpeed = 0;
    public int bonusWalkSpeed = 0;
    public int bonusDodgeChance = 0;
    public int bonusSkinThickness = 0;
          
    public int chainLightning = 0;
    public int flameThrower = 0;
    public int explosion = 0;
    public int spikes = 0;
    public int chainsaw = 0;
    
    public int magnet = 0;
    public int whirlwind = 0;
    public int bonusVsOrcs = 0;
    public int bonusVsGoblins = 0;   
     
    public float EndTime;
}

public class GameUnit : MonoBehaviour
{
	public int baseStrength = 0;
	public int baseAttackSpeed = 0;
	public int baseWalkSpeed = 0;
	public int baseDodgeChance = 0;
	public int baseSkinThickness = 0;
	
    public int strength = 0;
    public int attackSpeed = 0;
    public int walkSpeed = 0;
    public int dodgeChance = 0;
    public int skinThickness = 0;    
      
    public int chainLightning = 0;
    public int flameThrower = 0;
    public int explosion = 0;
    public int spikes = 0;
    public int chainsaw = 0;
    
    public int magnet = 0;
    public int whirlwind = 0;
    public int bonusVsOrcs = 0;
    public int bonusVsGoblins = 0;   
     

    public int hitPoints = 100;

    public int combinedStrength { get { return baseStrength + strength*5; } }
    public float combinedAttackSpeed { get { return (float)( baseAttackSpeed + attackSpeed ) * 0.25f; } }
    public float combinedWalkSpeed { get { return (float)( baseWalkSpeed + walkSpeed*2 ); } }
    public float combinedDodgeChance {get {return (float)( baseDodgeChance + dodgeChance*0.03f);}}
    public float combinedSkinThickness {get {return (float)( baseSkinThickness + skinThickness*0.05f);}}

    Queue<Buff> buffs = new Queue<Buff>();
	
	// Update is called once per frame
	void Update ()
    {
        UpdateBuffs();
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
        dodgeChance -= buff.bonusDodgeChance;
        skinThickness -= buff.bonusSkinThickness;
        
        chainLightning -= buff.chainLightning;
        flameThrower -= buff.flameThrower;
        explosion -= buff.explosion;
        spikes -= buff.spikes;
        chainsaw -= buff.chainsaw;
        
        magnet -= buff.magnet;
        whirlwind -= buff.whirlwind;
        bonusVsOrcs -= buff.bonusVsOrcs;
        bonusVsGoblins -= buff.bonusVsGoblins;
        
        UpdateBuffs();
    }

    public void AddBuff( Buff buff )
    {
        strength += buff.bonusStrength;
        attackSpeed += buff.bonusAttackSpeed;
        walkSpeed += buff.bonusWalkSpeed;
        dodgeChance += buff.bonusDodgeChance;
        skinThickness += buff.bonusSkinThickness;
  
        chainLightning += buff.chainLightning;
        flameThrower += buff.flameThrower;
        explosion += buff.explosion;
        spikes += buff.spikes;
        chainsaw += buff.chainsaw;
        
        magnet += buff.magnet;
        whirlwind += buff.whirlwind;
        bonusVsOrcs += buff.bonusVsOrcs;
        bonusVsGoblins += buff.bonusVsGoblins;
        
        buff.EndTime = Time.time + 10f;
        buffs.Enqueue( buff );
    }

    public void ReceiveDamage( int damage )
    {
        Debug.Log( this + " has received " + damage + " damage." );
        hitPoints -= damage;
        if( hitPoints <= 0 )
        {
            GameObject.Destroy( gameObject );
        }
    }

    void OnDisable()
    {
        if( !gameObject.activeInHierarchy )
            buffs.Clear();
    }
	
}
