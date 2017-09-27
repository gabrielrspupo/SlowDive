using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {	
	public Transform []positions;
	public Transform currentPos;
	public float speed = 2.0f;

	private Transform platform;
	private Rigidbody2D rb;
	private int pointSelected;
	private TimeManager localTime;

	void Start(){
		platform = transform;
		localTime = GameObject.Find ("TimeManager").GetComponent<TimeManager> ();

		pointSelected = 0;
		currentPos = positions [pointSelected];
		transform.position = currentPos.position;

		rb =  GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate(){
        if (pointSelected >= 0) {
            Vector2 newPosition = new Vector2(transform.position.x + speed * localTime.localDeltaTime(), transform.position.y);
            rb.MovePosition(newPosition);
        }
		
		/*
		if (transform.position == currentPos.position)
			pointSelected++;*/
	}    
}
