using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aaron : MonoBehaviour {
	private Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}
	private void OnCollisionEnter2D(Collision2D collision){
		Debug.Log("aaaa");
		if (collision.transform.tag.Equals("Player")){
			collision.transform.GetComponent<Player>().velocidade = 0;
			Levanta();
		}
	}
	private void Levanta(){
		animator.SetBool("comecar", true);
		StartCoroutine("Pausar");
	}
	IEnumerator Pausar(){
		yield return new WaitForSeconds(3.0f);
		Pisca();
	}
	private void Pisca(){
		animator.SetBool("piscar", true);
		StartCoroutine("Pausar2");
	}
	IEnumerator Pausar2(){
		yield return new WaitForSeconds(3.0f);
		animator.SetBool("final", true);
	}
}
