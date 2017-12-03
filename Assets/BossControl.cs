using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : MonoBehaviour {
    public GameObject[] patterns;
    public float timeToFire;

    private float timer;
    private TimeManager localTime;
    // Use this for initialization
    void Start () {
        localTime = GameObject.Find("TimeManager").GetComponent<TimeManager>();
    }
	
	// Update is called once per frame
	void Update () {
        timer -= localTime.localDeltaTime();
        if (timer <= 0f)
        {
            Fire(0);
            timer = timeToFire;
        }
    }

    void Fire(int pattern)
    {
        patterns[pattern].GetComponent<FirePattern>().Fire();
    }
}
