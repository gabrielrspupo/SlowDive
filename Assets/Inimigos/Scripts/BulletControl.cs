using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {
    [SerializeField]
    private float bulletSpeed;
    private float _time;
    // Use this for initialization
    void Start () {
        _time = 0;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * bulletSpeed);
        _time += Time.deltaTime;
        if (_time > 10)
            GameObject.Destroy(gameObject);
	}

    private void OnTriggerEnter2D(Collider2D collision) {           
        if (!collision.transform.tag.Contains("Enemy"))
            GameObject.Destroy(gameObject);
    }
}
