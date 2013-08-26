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

    public static void BinaryWrite( System.IO.BinaryWriter bw, HighScore score )
    {
        bw.Write( score.Name );
        bw.Write( score.Score );
    }

    public static HighScore BinaryRead( System.IO.BinaryReader br )
    {
        string name = br.ReadString();
        int score = br.ReadInt32();
        return new HighScore( name, score );
    }

    public static int Compare( HighScore left, HighScore right )
    {
        return right.Score.CompareTo( left.Score );
    }
}

public static class HighScoreManager
{
    public static List<HighScore> Scores = new List<HighScore>();

    static HighScoreManager()
    {
        LoadFromDisk();
    }

    public static void Add( HighScore highScore )
    {
        Scores.Add( highScore );
        Scores.Sort( HighScore.Compare );
        while( Scores.Count > 10 )
            Scores.RemoveAt( Scores.Count - 1 );

        SaveToDisk();
    }

    public static void SaveToDisk()
    {
        IO.WriteToFile( "Highscore.bin", ( bw ) =>
        {
            IO.WriteArray( bw, Scores, HighScore.BinaryWrite );
        } );
    }

    static void LoadFromDisk()
    {
        IO.ReadFromFile( "Highscore.bin", ( br ) =>
        {
            HighScore[] scores = IO.ReadArray<HighScore>( br, HighScore.BinaryRead );
            Scores.Clear();
            Scores.AddRange( scores );
        } );
    }
}
