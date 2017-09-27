using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDropper : MonoBehaviour {
	public GameObject box;
	public float timeToInstantiate = 5f;

	private TimeManager localTime;
	private float timer;

	// Use this for initialization
	void Start () {
		localTime = GameObject.Find ("TimeManager").GetComponent<TimeManager> ();
		timer = timeToInstantiate;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= localTime.localDeltaTime ();
		if (timer <= 0f) {
			Instantiate (box, transform.position, Quaternion.identity);
			timer = timeToInstantiate;
		}
	}
}
