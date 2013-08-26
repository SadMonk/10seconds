using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static T RandomEntry<T>( this List<T> list )
    {
        if( list.Count == 0 )
            return default( T );
        else
            return list[Random.Range( 0, list.Count )];
    }

    public static T RandomEntry<T>( this List<T> list, int min, int max )
    {
        if( list.Count == 0 )
            return default( T );
        else
            return list[Random.Range( min, max )];
    }
}
