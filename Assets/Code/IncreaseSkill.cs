using UnityEngine;
using System.Collections;

public class IncreaseSkill : MonoBehaviour {

    public int KillCost;
    public SkillType skillType;

    void OnMouseDown()
    {
        if( Game.KillCount >= KillCost )
        {
            Game.KillCount -= KillCost;
            switch( skillType )
            {
                case SkillType.Life: if( Game.SkillLife < 10 ) Game.SkillLife += 1; break;
                case SkillType.Damage: if( Game.SkillDamage < 10 ) Game.SkillDamage += 1; break;
                case SkillType.Regen: if( Game.SkillRegen < 10 ) Game.SkillRegen += 1; break;
            }
            Game.SaveSkills();
        }
    }
}
