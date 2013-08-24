using UnityEngine;
using System.Collections;

public class Buff_Strength : MonoBehaviour, Buff {
	
	public int modifier = 5;
	public float duration = 10f;
	private float activationTime;
	private Player player;
	public int buffType = BuffTypes.Strength;
	
	/// <summary>
	/// Enables the buff for the player.
	/// </summary>
	/// <param name='player'>
	/// Player.
	/// </param>
	public void enable(Player player)
	{
		this.player = player;
		player.strength += modifier;
	}
	
	/// <summary>
	/// Disable this instance.
	/// </summary>
	public void disable()
	{
		if(player != null) {
			player.strength -= modifier;
		}
	}
	
	/// <summary>
	/// Checks if the buff is over and disables it.
	/// </summary>
	private void checkEnd()
	{
		if(Time.time > this.activationTime + duration) {
			this.disable();
		}
	}
	
	/// <summary>
	/// Gets the type.
	/// </summary>
	/// <returns>
	/// The type.
	/// </returns>
	public string getType() {
		return buffType;
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
