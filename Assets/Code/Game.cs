using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {
	
	public Player player;
	public List<Enemy> enemies;
	List<Buff> buffs;

    GameObject PlayerPrefab;
    GameObject EnemyPrefab;

    CameraComponent camera;

    public static Game Instance;

    void LoadPrefabs()
    {
        PlayerPrefab = (GameObject)Resources.Load( "Prefab/PlayerPrefab", typeof( GameObject ) );
        EnemyPrefab = (GameObject)Resources.Load( "Prefab/EnemyPrefab", typeof( GameObject ) );
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
	
	// Use this for initialization
	void Start () {
        Instance = this;
        LoadPrefabs();
        camera = (CameraComponent)FindObjectOfType( typeof( CameraComponent ) );
        player = SpawnPlayer( Vector3.zero );
        enemies.Add( SpawnEnemy( new Vector3( -5, 0, 0 ) ) );
		Debug.Log("game initialized");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
