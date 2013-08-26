using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
    public static Game Instance;

	public Player player;
	public List<Enemy> enemies;
    public List<GameObject> spawners;
	List<Buff> buffs;
	public List<Drop> drops;

    public GameObject PlayerPrefab;
    public GameObject EnemyPrefab1;
    public GameObject EnemyPrefab2;
	public GameObject spawnDropPrefab;
    public GameObject DamageTextPrefab;

    CameraComponent gameCamera;

    public float LastSpawnTime = 0f;
    public float SpawnRate = 10f;
    public int SpawnAmount = 2;
 
    public static bool isShuttingDown = false;
    
    public static int KillCount = 0;
    public static int SkillLife = 0;
    public static int SkillDamage = 0;
    public static int SkillRegen = 0;
    
    void OnApplicationQuit()
    {
        isShuttingDown = true;
    }
      

    void LoadSpawners()
    {
        foreach( var obj in FindObjectsOfType( typeof( GameObject ) ) )
        {
            var go = obj as GameObject;
            if( go.tag == "Spawner" )
                spawners.Add( go );
        }
    }

    Player SpawnPlayer( Vector3 position )
    {
        GameObject player = GameObject.Instantiate( PlayerPrefab, position, Quaternion.identity ) as GameObject;
        gameCamera.FollowTarget = player;
        return player.GetComponent<Player>();
    }
	
	Enemy SpawnEnemy ( GameObject enemyPrefab, Vector3 position )
	{
		GameObject enemy = GameObject.Instantiate( enemyPrefab, position, Quaternion.identity ) as GameObject;
        return enemy.GetComponent<Enemy>();
	}
	
	public Drop SpawnDrop ( Vector3 position, GameObject dropPrefab )
	{
		GameObject drop = GameObject.Instantiate( dropPrefab, position, Quaternion.identity ) as GameObject;
        // Todo: add drop to drop-list in here?
		return drop.GetComponent<Drop>();
	}
	
	// Use this for initialization
	void Start () {
        Instance = this;
        LoadSkills();
        Game.KillCount = 0;
        LoadSpawners();
        gameCamera = (CameraComponent)FindObjectOfType( typeof( CameraComponent ) );
        player = SpawnPlayer( Vector3.zero );
		Drop testDrop = SpawnDrop( new Vector3( 5, 0, 0 ) , spawnDropPrefab );				
		drops.Add( testDrop );
		Debug.Log("game initialized");
	}
    
    public void DisplayText( Transform target, Vector3 offset, Vector3 velocity, string text, Color color, int size = 20 )
    {
        GameObject go = GameObject.Instantiate( DamageTextPrefab ) as GameObject;
        ObjectLabel ol = go.GetComponent<ObjectLabel>();
        GUIText gt = go.GetComponent<GUIText>();
        ol.target = target;
        ol.velocity = velocity;
        ol.offset = offset;
        gt.text = text;
        gt.color = color;
        gt.fontSize = size;
        GameObject.Destroy( go, 1f );
    }

    public void TriggerSpawners()
    {
        if( LastSpawnTime + SpawnRate < Time.time )
        {
            for( int i = 0; i < SpawnAmount; i++ )
            {
                var randomSpawner = spawners[Random.Range( 0, spawners.Count )];
                if( Random.Range( 0, 1000 ) <= 66 )
                    enemies.Add( SpawnEnemy( EnemyPrefab2, randomSpawner.transform.position ) );
                else
                    enemies.Add( SpawnEnemy( EnemyPrefab1, randomSpawner.transform.position ) );
            }

            if( SpawnAmount < 10 )
                SpawnAmount += 1;
            else if( SpawnAmount < 20 )
                SpawnAmount += 2;
            else if( SpawnAmount < 100 )
                SpawnAmount += 3;

            LastSpawnTime = Time.time;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        TriggerSpawners();
	}

    void LoadSkills()
    {
        IO.ReadFromFile( "Skills.bin", ( br ) =>
        {
            SkillDamage = br.ReadInt32();
            SkillLife = br.ReadInt32();
            SkillRegen = br.ReadInt32();
        } );

        Debug.Log( SkillRegen );
    }

    public static void SaveSkills()
    {
        IO.WriteToFile( "Skills.bin", ( bw ) =>
        {
            bw.Write( SkillDamage );
            bw.Write( SkillLife );
            bw.Write( SkillRegen );
        } );
    }
}
