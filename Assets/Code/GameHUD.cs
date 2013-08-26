using UnityEngine;
using System.Collections;

public class GameHUD : MonoBehaviour {
 
    
    public Texture2D healthIcon;
    public Texture2D strengthIcon;
    public Texture2D attackSpeedIcon;
    public Texture2D walkingSpeedIcon;
    public Texture2D skinThicknessIcon;
    public Texture2D chainLightningIcon;
    public Texture2D spikesIcon;
    public Texture2D magnetIcon;
    public Texture2D whirlwindIcon;
    public Texture2D trapIcon;
    public Texture2D bombIcon;
    
    public float height = 25f;
    
    
	void OnGUI() 
    {
        int currentScore = Game.KillCount;
        
        GUILayout.BeginHorizontal("box");
        
        GUILayout.Label("Banished:",GUILayout.Height(height));
        GUILayout.Label(currentScore.ToString(),GUILayout.Height(height));
        ShowStat(healthIcon,Game.Instance.player.gameUnit.hitPoints);
        ShowStat(strengthIcon,Game.Instance.player.gameUnit.strength);
        ShowStat(attackSpeedIcon,Game.Instance.player.gameUnit.attackSpeed);
        ShowStat(walkingSpeedIcon,Game.Instance.player.gameUnit.walkSpeed);
        ShowStat(skinThicknessIcon,Game.Instance.player.gameUnit.skinThickness);
        ShowStat(chainLightningIcon,Game.Instance.player.gameUnit.chainLightning);
        ShowStat(spikesIcon,Game.Instance.player.gameUnit.spikes);
        ShowStat(magnetIcon,Game.Instance.player.gameUnit.magnet);
        ShowStat(whirlwindIcon,Game.Instance.player.gameUnit.whirlwind);
        ShowStat(trapIcon,Game.Instance.player.gameUnit.trap);
        ShowStat(bombIcon,Game.Instance.player.gameUnit.bomb);
        
        
        GUILayout.EndHorizontal();
    }
    
    /// <summary>
    /// Shows the buff, if we've collected one.
    /// </summary>
    /// <param name='icon'>
    /// Icon.
    /// </param>
    /// <param name='counter'>
    /// Counter.
    /// </param>
    void ShowStat(Texture2D icon, int counter)
    {
        if(counter != 0) 
        {            
            float width = icon.width / (icon.height/height);
            GUILayout.Label(icon,GUILayout.Height(height),GUILayout.Width(width));
            GUILayout.Label (counter.ToString(),GUILayout.Height(height));
        }
    }
    
}
