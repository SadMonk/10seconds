using UnityEngine;
using System.Collections;

public class LifeRegeneration : MonoBehaviour
{
    public int RegenRate;
    public float NextRegenTime;

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
        if( NextRegenTime < Time.time )
        {
            gameUnit.hitPoints += RegenRate;
            NextRegenTime = Time.time + 1f;
        }
    }
}
