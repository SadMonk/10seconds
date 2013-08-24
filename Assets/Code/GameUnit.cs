using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BuffTest : MonoBehaviour
{
    public int bonusStrength = 0;
    public int bonusAttackSpeed = 0;
    public int bonusWalkSpeed = 0;
    public int bonusDodgeChance = 0;
    public int bonusSkinThickness = 0;

    public float EndTime;
}

public class GameUnit : MonoBehaviour
{
    public int strength = 0;
    public int attackSpeed = 0;
    public int walkSpeed = 0;
    public int dodgeChance = 0;
    public int skinThickness = 0;

    Queue<BuffTest> buffs = new Queue<BuffTest>();
	
	// Update is called once per frame
	void Update ()
    {
        UpdateBuffs();
	}

    void UpdateBuffs()
    {
        BuffTest buff = buffs.Peek();
        if( buff == null ) return;
        if( buff.EndTime > Time.time ) return;

        buffs.Dequeue();
        strength -= buff.bonusStrength;
        attackSpeed -= buff.bonusAttackSpeed;
        walkSpeed -= buff.bonusWalkSpeed;
        dodgeChance -= buff.bonusDodgeChance;
        skinThickness -= buff.bonusSkinThickness;
        UpdateBuffs();
    }

    public void AddBuff( BuffTest buff )
    {
        strength += buff.bonusStrength;
        attackSpeed += buff.bonusAttackSpeed;
        walkSpeed += buff.bonusWalkSpeed;
        dodgeChance += buff.bonusDodgeChance;
        skinThickness += buff.bonusSkinThickness;

        buff.EndTime = Time.time + 10f;
        buffs.Enqueue( buff );
    }

    void OnDisable()
    {
        buffs.Clear();
    }
}
