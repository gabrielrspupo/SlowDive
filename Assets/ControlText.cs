using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlText : MonoBehaviour {
	private float timer = 5f;
	private TimeManager localTime;

	// Use this for initialization
	void Start () {
		localTime = GameObject.Find("TimeManager").GetComponent<TimeManager>();	
	}
	
	// Update is called once per frame
	void Update () {
		timer -= localTime.localDeltaTime ();
		if (timer <= 0f) {
			gameObject.SetActive (false);
		}
	}
}
