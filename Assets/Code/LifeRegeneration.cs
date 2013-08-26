using UnityEngine;
using System.Collections;

public class LifeRegeneration : MonoBehaviour
{
    public int RegenRate;
    public float LastRegenTime;

    GameUnit gameUnit;

    void Awake()
    {
        gameUnit = GetComponent<GameUnit>();
    }

    void Start()
    {
        RegenRate = Game.SkillRegen;
    }

    // Update is called once per frame
    void Update()
    {
        if( LastRegenTime + 1f < Time.time )
        {
            gameUnit.hitPoints += RegenRate;
            LastRegenTime = Time.time;
        }
    }
}
