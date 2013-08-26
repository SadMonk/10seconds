using UnityEngine;
using System.Collections;

public class DisplayCurrentScore : MonoBehaviour
{
    TextMesh textMesh;

    void Awake()
    {
        textMesh = GetComponent<TextMesh>();
    }

    // Use this for initialization
    void Start()
    {
        if( guiText != null )
            guiText.text = Game.KillCount.ToString();
    }

    void Update()
    {
        if( textMesh != null )
            textMesh.text = "Kills: " + Game.KillCount.ToString();
    }
}
