using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Bala : MonoBehaviour {

	[SerializeField]
	private float velocidade;
	private Vector2 direcao;
	private Rigidbody2D rb;
	[SerializeField]
	private GameObject explosao;
	private float tempo = 0.38f;
	private SpriteRenderer renderer;
	private bool instanciou = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.velocity = direcao*velocidade;
	}
	public void Inicializar(Vector2 _direcao){
		direcao = _direcao;
		renderer = GetComponent<SpriteRenderer>();
		instanciou = true;
		if(direcao==Vector2.left){
			transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		}
	}
	void OnBecameInvisible(){
		Destroy(gameObject);
	}
	void OnCollisionEnter2D(Collision2D outro){
		if(gameObject!=null && outro!=null && !outro.transform.CompareTag("Player")){
			explosao.SetActive(true);
			if(renderer!=null)
				renderer.material.color = new Color(1.0f,1.0f,1.0f,0.0f);
			StartCoroutine("Destruir");
		}
	}
	IEnumerator Destruir(){
		yield return new WaitForSeconds(tempo);
		Destroy(gameObject);
	}
}
