using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour
{
    public float UnitSize = 0.06f;

    public int Progress;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale = new Vector3( (float)Progress * UnitSize, transform.localScale.y, transform.localScale.z );
	}
}
