using UnityEngine;
using System.Collections;

[RequireComponent( typeof( TextMesh ) )]
public class DisplayHighscoreScores : MonoBehaviour
{
    TextMesh textMesh;

    void Awake()
    {
        textMesh = GetComponent<TextMesh>();
    }

    // Use this for initialization
    void Start()
    {
        textMesh.text = "";

        int i = 1;
        foreach( var score in HighScoreManager.Scores )
        {
            textMesh.text += score.Score.ToString() + "\n";
            i++;
        }
    }
}
