using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {
	
	Player player;
	List<Enemy> enemies;
	List<Buff> buffs;

    GameObject PlayerPrefab;
    GameObject EnemyPrefab;

    CameraComponent camera;

    void LoadPrefabs()
    {
        PlayerPrefab = (GameObject)Resources.Load( "Prefab/PlayerPrefab", typeof( GameObject ) );
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
		this.enemies.Add(enemy.GetComponent<Enemy>());
	}
	
	// Use this for initialization
	void Start () {
        LoadPrefabs();
        camera = (CameraComponent)FindObjectOfType( typeof( CameraComponent ) );
        player = SpawnPlayer( Vector3.zero );
		Debug.Log("game initialized");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
