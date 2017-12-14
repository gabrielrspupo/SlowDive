using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisivel : MonoBehaviour {
	private SpriteRenderer renderer;
	// Use this for initialization
	void Start () {
		renderer = GetComponent<SpriteRenderer>();
		renderer.material.color = new Color(1.0f,1.0f,1.0f,0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
