using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

public static partial class IO
{
    public static T LoadXml<T>( string path ) where T : class
    {
        T data = null;
        XmlSerializer serializer = new XmlSerializer( typeof( T ) );

        using( StreamReader sr = new StreamReader( path ) )
        {
            data = (T)serializer.Deserialize( sr );
        }
        return data;
    }

    public static void SaveXml( string path, object obj, XmlRootAttribute rootAttribute = null )
    {
        try
        {
            System.Xml.Serialization.XmlSerializer writer = null;
            if( rootAttribute != null )
                writer = new System.Xml.Serialization.XmlSerializer( obj.GetType(), rootAttribute );
            else
                writer = new System.Xml.Serialization.XmlSerializer( obj.GetType() );

            StreamWriter streamWriter = new StreamWriter( path );
            writer.Serialize( streamWriter, obj );
            streamWriter.Close();
        }
        catch( Exception ) { throw; }
    }

    public static T[] ReadArray<T>( BinaryReader br, Func<BinaryReader, T> readElementMethod )
    {
        T[] data = new T[br.ReadInt32()];
        for( int i = 0; i < data.Count(); i++ )
            data[i] = readElementMethod( br );

        return data;
    }

    public static T[][] ReadArrayOfArray<T>( BinaryReader br, Func<BinaryReader, T> readElementMethod )
    {
        T[][] data = new T[br.ReadInt32()][];
        for( int i = 0; i < data.Count(); i++ )
        {
            data[i] = new T[br.ReadInt32()];
            for( int j = 0; j < data[i].Count(); j++ )
                data[i][j] = readElementMethod( br );
        }

        return data;
    }

    public static void WriteArray<T>( BinaryWriter bw, IEnumerable<T> data, Action<BinaryWriter, T> writeElementMethod )
    {
        bw.Write( data.Count() );
        foreach( T element in data )
            writeElementMethod( bw, element );
    }

    public static void WriteArrayOfArray<T>( BinaryWriter bw, IEnumerable<IEnumerable<T>> data, Action<BinaryWriter, T> writeElementMethod )
    {
        bw.Write( data.Count() );
        foreach( IEnumerable<T> array in data )
        {
            bw.Write( array.Count() );
            foreach( T arrayElement in array )
                writeElementMethod( bw, arrayElement );
        }
    }

    public static void WriteToFile( string path, Action<BinaryWriter> action )
    {
        FileStream fs = null;
        try
        {
            fs = new FileStream( path, FileMode.Create );
        }
        catch( System.Exception )
        {

        }
        finally
        {
            if( fs != null )
            {
                BinaryWriter bw = new BinaryWriter( fs );
                action( bw );
                bw.Close();
                fs.Close();
            }
        }
    }

    public static void ReadFromFile( string path, Action<BinaryReader> action )
    {
        FileStream fs = null;
        try
        {
            fs = new FileStream( path, FileMode.Open );
        }
        catch( System.Exception )
        {

        }
        finally
        {
            if( fs != null )
            {
                BinaryReader br = new BinaryReader( fs );
                action( br );
                br.Close();
                fs.Close();
            }
        }
    }
}
