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

    GameObject PlayerPrefab;
    GameObject EnemyPrefab;
	GameObject DropPrefab;
    GameObject DamageTextPrefab;

    CameraComponent camera;

    public float LastSpawnTime = 0f;
    public float SpawnRate = 4f;

    void LoadPrefabs()
    {
        PlayerPrefab = (GameObject)Resources.Load( "Prefab/PlayerPrefab", typeof( GameObject ) );
        EnemyPrefab = (GameObject)Resources.Load( "Prefab/EnemyPrefab", typeof( GameObject ) );
		DropPrefab = (GameObject)Resources.Load( "Prefab/DropPrefab" , typeof( GameObject) );
        DamageTextPrefab = (GameObject)Resources.Load( "Prefab/DamageText", typeof( GameObject ) );
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
        camera.FollowTarget = player;
        return player.GetComponent<Player>();
    }
	
	Enemy SpawnEnemy ( Vector3 position )
	{
		GameObject enemy = GameObject.Instantiate( EnemyPrefab, position, Quaternion.identity ) as GameObject;
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
        LoadPrefabs();
        LoadSpawners();
        camera = (CameraComponent)FindObjectOfType( typeof( CameraComponent ) );
        player = SpawnPlayer( Vector3.zero );
        enemies.Add( SpawnEnemy( new Vector3( -5, 0, 0 ) ) );
		Drop testDrop = SpawnDrop( new Vector3( 5, 0, 0 ) , DropPrefab );
		testDrop.buff=new Buff();
		testDrop.buff.bonusWalkSpeed=10;		
		drops.Add( testDrop );
		Debug.Log("game initialized");
	}

    public void DisplayText( Transform target, Vector2 offset, Vector2 velocity, string text, Color color, int size = 20 )
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
            var randomSpawner = spawners[Random.Range( 0, spawners.Count - 1 )];
            SpawnEnemy( randomSpawner.transform.position );
            LastSpawnTime = Time.time;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        TriggerSpawners();
	}
}
