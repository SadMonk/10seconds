using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGen : MonoBehaviour
{
    public float LevelWidth;
    public float LevelHeight;
    public float WallDistanceHorizontal;
    public float WallDistanceVertical;
    public float SpawnSafetyRange;

    public int WallCount;
    public int StoneCount;
    public int SpawnerCount;

    public List<GameObject> HorizontalWallPrefabs;
    public List<GameObject> VerticalWallPrefabs;
    public List<GameObject> StonePrefabs;
    public GameObject SpawnerPrefab;

    List<GameObject> AllWallPrefabs = new List<GameObject>();
    float halfWidth { get { return LevelWidth * 0.5f; } }
    float halfHeight { get { return LevelHeight * 0.5f; } }


	// Use this for initialization
	void Awake ()
    {
        AllWallPrefabs.AddRange( HorizontalWallPrefabs );
        AllWallPrefabs.AddRange( VerticalWallPrefabs );

        GenerateOuterWalls();
        GenerateDecorations();
        GenerateSpawners();
	}
	
    void GenerateOuterWalls()
    {
        // top and bottom
        for( float x = -halfWidth + WallDistanceHorizontal * 0.5f; x < halfWidth + WallDistanceHorizontal * 0.5f; x += WallDistanceHorizontal )
        {
            Instantiate( HorizontalWallPrefabs.RandomEntry(), new Vector3( x, -halfHeight ), Quaternion.identity );
            Instantiate( HorizontalWallPrefabs.RandomEntry(), new Vector3( x,  halfHeight ), Quaternion.identity );
        }

        // left and right
        for( float y = -halfHeight; y < halfHeight; y += WallDistanceVertical )
        {
            Instantiate( VerticalWallPrefabs.RandomEntry(), new Vector3( -halfWidth, y ), Quaternion.identity );
            Instantiate( VerticalWallPrefabs.RandomEntry(), new Vector3(  halfWidth, y ), Quaternion.identity );
        }
    }

    void GenerateDecorations()
    {
        // inner walls
        for( int i = 0; i < WallCount; i++ )
            Instantiate( AllWallPrefabs.RandomEntry(), GetRandomPositionWithinWalls(), Quaternion.identity );

        // stones
        for( int i = 0; i < StoneCount; i++ )
        {
            Vector3 pos = GetRandomPositionWithinWalls( false );
            pos = new Vector3( pos.x, pos.y, pos.y * ZLevelSorter.ZLevelMultiplyer + 500f );
            Instantiate( StonePrefabs.RandomEntry(), pos, Quaternion.AngleAxis( Random.Range( 0f, 360f ), Vector3.forward ) );
        }
    }

    void GenerateSpawners()
    {
        for( int i = 0; i < SpawnerCount; i++ )
            Instantiate( SpawnerPrefab, GetRandomPositionWithinWalls(), Quaternion.identity );
    }

    bool IsSafeToSpawn( Vector2 position )
    {
        float x = Mathf.Abs( position.x );
        float y = Mathf.Abs( position.y );

        return x > SpawnSafetyRange && y > SpawnSafetyRange;
    }

    Vector2 GetRandomPositionWithinWalls( bool spawnSafety = true )
    {
        Vector2 p = Vector2.zero;

        while( true )
        {
            p = new Vector2(
            Random.Range( -halfWidth * 0.95f, halfWidth * 0.95f ),
            Random.Range( -halfHeight * 0.95f, halfHeight * 0.95f ) );
            if( spawnSafety )
            {
                if( !IsSafeToSpawn( p ) )
                    continue;
            }
            break;
        }

        return p;
    }
}
