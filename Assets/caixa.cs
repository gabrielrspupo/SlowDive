using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caixa : MonoBehaviour {
	private Animator animator;
	public ProgressBar progressBar;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}
	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.transform.tag.Contains("Player")){
			animator.SetBool("ativar", true);
		}
	}
	private void OnTriggerStay2D(Collider2D collision) {
		if (collision.transform.tag.Contains("Player")){
			if(collision.GetComponent<Player>().energy<2500)
				collision.GetComponent<Player>().energy = 2500.0f;
			progressBar.AtualizaEnergia(0f);
		}
	}
	private void OnTriggerExit2D(Collider2D collision) {
		if (collision.transform.tag.Contains("Player")){
			animator.SetBool("ativar", false);
		}
	}
}
