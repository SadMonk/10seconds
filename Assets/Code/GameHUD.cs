using UnityEngine;
using System.Collections;

public class GameHUD : MonoBehaviour {
 
    public Texture2D strengthIcon;
    public Texture2D attackSpeedIcon;
    public Texture2D walkingSpeedIcon;
    public Texture2D skinThicknessIcon;
    public Texture2D chainLightningIcon;
    public Texture2D spikesIcon;
    public Texture2D magnetIcon;
    public Texture2D whirlwindIcon;
    public Texture2D trapIcon;
    
	void OnGUI() 
    {
        GUILayout.BeginArea(new Rect(0,0,Screen.width,50));
        
        GUILayout.Label("Score:");
        
        GUILayout.EndArea();
    }
}
