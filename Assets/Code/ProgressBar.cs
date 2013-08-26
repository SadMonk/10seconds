using UnityEngine;
using System.Collections;

public enum SkillType
{
    None,
    Life,
    Damage,
    Regen
}

public class ProgressBar : MonoBehaviour
{
    public float UnitSize = 0.06f;
    public SkillType ProgressType;

	// Use this for initialization
	void Start () {
	
	}

    int GetProgress()
    {
        switch( ProgressType )
        {
            case SkillType.Life: return Game.SkillLife;
            case SkillType.Damage: return Game.SkillDamage;
            case SkillType.Regen: return Game.SkillRegen;
            default: return 0;
        }
    }

	// Update is called once per frame
	void Update () {
        transform.localScale = new Vector3( (float)GetProgress() * UnitSize, transform.localScale.y, transform.localScale.z );
	}
}
