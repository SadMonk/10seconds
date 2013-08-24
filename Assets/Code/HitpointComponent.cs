using UnityEngine;
using System.Collections;

public class HitpointComponent : MonoBehaviour {

    public int MaxHP;
    public int CurrentHP;

	// Use this for initialization
	void Start () {
        CurrentHP = MaxHP;
	}
	
	public void ReceiveDamage( int damage )
    {
        CurrentHP -= damage;
        CurrentHP = Mathf.Clamp( CurrentHP, 0, MaxHP );

        if( CurrentHP == 0 )
            GameObject.Destroy( gameObject );
    }
}
