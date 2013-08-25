using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Buff
{
    public int bonusStrength = 0;
    public int bonusAttackSpeed = 0;
    public int bonusWalkSpeed = 0;
    public int bonusSkinThickness = 0;
          
    public int chainLightning = 0;
    public int trap = 0;
    
    public int magnet = 0;
    public int whirlwind = 0; 
     
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
    public int trap = 0;
    
    public int magnet = 0;
    public int whirlwind = 0;  
     

    public int hitPoints = 100;

    public int combinedStrength { get { return baseStrength + strength*5; } }
    public float combinedAttackSpeed { get { return (float)( baseAttackSpeed + attackSpeed ) * 0.25f; } }
    public float combinedWalkSpeed { get { return (float)( baseWalkSpeed + walkSpeed*2 ); } }
    public float combinedSkinThickness {get {return (float)( baseSkinThickness + skinThickness*0.05f);}}

    Queue<Buff> buffs = new Queue<Buff>();
	
    // active buff states
    public bool IsWhirlwindEnabled = false;
    public float WhirlWindEndTime = 0f;

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
        trap -= buff.trap;
        
        magnet -= buff.magnet;
        whirlwind -= buff.whirlwind;
        
        UpdateBuffs();
    }

    public void AddBuff( Buff buff )
    {
        strength += buff.bonusStrength;
        attackSpeed += buff.bonusAttackSpeed;
        walkSpeed += buff.bonusWalkSpeed;
        skinThickness += buff.bonusSkinThickness;
  
        chainLightning += buff.chainLightning;
        trap += buff.trap;
        
        magnet += buff.magnet;
        whirlwind += buff.whirlwind;
        
        buff.EndTime = Time.time + 10f;
        if( buff.whirlwind > 0 ) buff.EndTime += 10000000;
        buffs.Enqueue( buff );
    }

    public void ReceiveDamage( int damage )
    {
        Color textColor = GetComponent<Enemy>() ? Color.white : Color.red;

        int actualDamage = (int)Mathf.Round( Mathf.Max( damage * ( 1.20f - (float)skinThickness * 0.05f ), 1f ) );
        hitPoints -= actualDamage;
        Game.Instance.DisplayText( transform, new Vector3( 0, 1.95f, 0f ), new Vector3( 0, 2f ), actualDamage.ToString(), textColor );
        Game.Instance.DisplayText( transform, new Vector3( 0, 2f, -0.001f ), new Vector3( 0, 2f ), actualDamage.ToString(), Color.black );
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
