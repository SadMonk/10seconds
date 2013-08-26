using UnityEngine;
using System.Collections;

public class HighScoreInput : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        foreach( char c in Input.inputString )
        {
            // Clear "Enter Name" on first key stroke
            if( guiText.text == "Enter Name" )
                guiText.text = "";

            if( c == "\b"[0] ) // backspace
            {
                if( guiText.text.Length != 0 )
                    guiText.text = guiText.text.Substring( 0, guiText.text.Length - 1 );
            }

            else
            {
                if( c == "\n"[0] || c == "\r"[0] ) // hit enter
                {
                    print( "User entered his name: " + guiText.text );
                    HighScoreManager.Add( new HighScore( guiText.text, Game.KillCount ) );
                    Application.LoadLevel( "HighScore" );
                }
                else
                    guiText.text += c; // add text
            }
        }
    }
}
