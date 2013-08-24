using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour {
	
	void OnCollisionEnter (Collision col)
    {
		Debug.Log("Collision with: " + col.gameObject.name);
        if(col.gameObject.name == "Drop")
        {
			//PickUpBuff(buff);
            Destroy(col.gameObject);
        }
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
