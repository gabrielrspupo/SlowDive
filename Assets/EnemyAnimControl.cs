using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimControl : MonoBehaviour {
    Animator anim;
    EnemyControl control;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        control = GetComponentInParent<EnemyControl>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (control.speed == 0)
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);
    }
}
