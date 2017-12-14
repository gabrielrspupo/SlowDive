using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    GameManager gameManager;
    private bool activate = false;
    private Animator animator;

    // Use this for initialization
    void Start () {
        gameManager = GameObject.Find("_GameManager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!activate) {
                gameManager.setSpawnPoint(transform);
                activate = true;
                animator.SetBool("active", true);
            }
        }
    }
}
