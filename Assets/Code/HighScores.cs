using System;
using System.Collections.Generic;
using UnityEngine;

public struct HighScore
{
    public string Name;
    public int Score;

    public HighScore( string name, int score )
    {
        Name = name;
        Score = score;
    }
}

public static class HighScoreManager
{
    public static List<HighScore> Scores = new List<HighScore>();

    static HighScoreManager()
    {
        Scores.Add( new HighScore( "TEST", 12345 ) );
    }

    public static void Add( HighScore highScore )
    {
        Scores.Add( highScore );
        Scores.Sort( ( scoreLeft, scoreRight ) => { return Convert.ToInt32( scoreLeft.Score >= scoreRight.Score ); } );
        while( Scores.Count > 10 )
            Scores.RemoveAt( Scores.Count - 1 );
    }
}
