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
                case SkillType.Life: Game.SkillLife += 1; break;
                case SkillType.Damage: Game.SkillDamage += 1; break;
                case SkillType.Regen: Game.SkillRegen += 1; break;
            }
            Game.SaveSkills();
        }
    }
}
