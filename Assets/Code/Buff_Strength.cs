using UnityEngine;
using System.Collections;

public class Buff_Strength : MonoBehaviour, Buff {
	
	public int modifier = 5;
	public float duration = 10f;
	private float activationTime;
	private Player player;
	
	public void enable(Player player)
	{
		this.player = player;
		player.strength += modifier;
	}
	
	public void disable()
	{
		if(player != null) {
			player.strength -= modifier;
		}
	}
	
	private void checkEnd()
	{
		if(Time.time > this.activationTime + duration) {
			this.disable();
		}
	}
		
	// Use this for initialization
	void Start () {
		this.activationTime = Time.time;
	}

	
	// Update is called once per frame
	void Update () {
		checkEnd();
	}
}
