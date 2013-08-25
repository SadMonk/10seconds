using UnityEngine;
using System.Collections;

public class Drop : MonoBehaviour {
	
	public Buff buff;
	
    public int bonusStrength = 0;
    public int bonusAttackSpeed = 0;
    public int bonusWalkSpeed = 0;
    public int bonusDodgeChance = 0;
    public int bonusSkinThickness = 0;
	
	// Use this for initialization
	void Start () {
        // initialize fitting buff stats.
		this.buff = new Buff();
        buff.bonusStrength = bonusStrength;
        buff.bonusAttackSpeed = bonusAttackSpeed;
        buff.bonusWalkSpeed = bonusWalkSpeed;
        buff.bonusDodgeChance = bonusDodgeChance;
        buff.bonusSkinThickness = bonusSkinThickness;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
}
