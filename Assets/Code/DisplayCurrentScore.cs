using UnityEngine;
using System.Collections;

[RequireComponent( typeof( GUIText ) )]
public class DisplayCurrentScore : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        guiText.text = Game.KillCount.ToString();
    }
}
