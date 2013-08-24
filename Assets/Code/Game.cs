using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	
	Player player;
	Enemy[] enemies;
	Buff[] buffs;

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
