using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

    public float speed = 1f;    
    private bool right = true;
	private TimeManager localTime;
	private Rigidbody2D rb;
	//private GroundCheck groundCheck;

	void Start(){
		localTime = GameObject.Find ("TimeManager").GetComponent<TimeManager> ();
			
		rb =  GetComponent<Rigidbody2D> ();

		//groundCheck = gameObject.GetComponentInChildren<GroundCheck> ();
	}
   
	private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ChangeDirTrigger")) {
			speed *= -1;
			Flip ();
        }
            
    }

    void FixedUpdate()
    {		
		/*if(groundCheck.isGrounded()){
			Vector2 newPosition = new Vector2(transform.position.x + speed * localTime.localDeltaTime(), transform.position.y);
			rb.MovePosition(newPosition);				
		}*/

    }
	void Flip(){
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
