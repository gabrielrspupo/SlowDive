using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feet : MonoBehaviour {
    private EnemyControl Control;
	// Use this for initialization
	void Start () {
        //gv = GetComponent<Gravity>();
        Control = this.transform.parent.GetComponent<EnemyControl>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    /*
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
            gv.isGrounded = true;
    }
    */
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Ground")) {
            Control.isGrounded = true;
            Debug.Log("Touched ground");
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Ground"))
        {
            Control.isGrounded = false;
            Debug.Log("Touched LEaving ground");
        }
    }
    
}
