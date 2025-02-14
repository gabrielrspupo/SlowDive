﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    private Rigidbody2D rb2D;
    private bool eLadoDireito;

    [SerializeField]
    private float velocidade = 0;
    private Animator animator;
    float horizontal;
    private bool acao;
	public float jumpImpulse = 10;
	private int jumpLimit = 1;
	public static bool paused = false;
   
    public float fallBoundary = -15;
    [SerializeField]
    private GameObject posicaoProjetil;
    [SerializeField]
    private GameObject projetil;
    public LayerMask plataforma;
    public Vector2 pontoColisaoPiso = Vector2.zero;
    public bool estaNoChao;
    public float raio;
    public Color debugCorColisao = Color.red;

    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float maxEnergy;
    [SerializeField]
    private float energyConsumeRate;

    [SerializeField]
    private float bulletDamage;
    [SerializeField]
    private float enemyDamage;//pode-se definir tipos de dano corporal diferente para cada inimigo

    private float health;
    private Image fillerHealth;
    private GameObject healthBar;    

    private float energy;
    private Image fillerEnergy;
    private GameObject energyBar;  
    private bool sofrerDano = false; 
    private int tipoDano = 0;
    private bool morreu = false;
    private BoxCollider2D boxCol;

    void Start(){
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCol = GetComponent<BoxCollider2D>();
        eLadoDireito = transform.localScale.x>0;

        fillerHealth = transform.Find("Health Canvas").GetChild(0).GetChild(0).GetComponent<Image>();
        healthBar = transform.Find("Health Canvas").gameObject;        
        health = maxHealth;
        fillerHealth.fillAmount = health / maxHealth;

        fillerEnergy = transform.Find("Energy Canvas").GetChild(0).GetChild(0).GetComponent<Image>();
        energyBar = transform.Find("Energy Canvas").gameObject;        
        energy = maxEnergy;
        fillerEnergy.fillAmount = energy / maxEnergy;
        animator.SetBool("morreu", false);
    }    

    void Update()
    {
        if (transform.position.y <= fallBoundary)
        {
            health = 0;
        }
        /*teste*/
        if (health <= 0){
            EstaNoChao();
            //GameObject.Destroy(gameObject);
            animator.SetLayerWeight(0,0);
            animator.SetLayerWeight(1,0);
            animator.SetLayerWeight(2,0);
            animator.SetLayerWeight(3,1);
            //transform.Find("Health Canvas").GetComponent<GameObject>().SetActive(false);
            healthBar.SetActive(false);
            energyBar.SetActive(false);
            animator.SetBool("morrendo", true);
            //rb2D.gravityScale = 5;
            morreu = true;
            rb2D.velocity = Vector2.zero;  
            boxCol.isTrigger = true;
            animator.SetBool("morto", true);
            pontoColisaoPiso.y = 0.18f;
            if(estaNoChao){
                rb2D.gravityScale = 0;
            }
            else{
                rb2D.gravityScale = 10;
            }
        }else{
            Resetar();
            ControlarEntradas();
        }
        
    }

    void FixedUpdate(){
        horizontal = Input.GetAxis("Horizontal");
        fillerHealth.fillAmount = health / maxHealth;
        fillerEnergy.fillAmount = energy / maxEnergy;

		if (Input.GetKeyDown (KeyCode.Escape))
			paused = !paused;

		if (!morreu && !paused) {
			rb2D.constraints = RigidbodyConstraints2D.FreezeRotation;
			LevouDano ();
			Movimentar (horizontal);
			MudarDirecao (horizontal);
			consumeEnergy ();
			EstaNoChao ();
			ControlarLayers ();
			Acao ();
		} else if (paused) {
			rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
		}
    }
    private void LevouDano(){
        if(sofrerDano){
            animator.SetBool("dano", true);
            animator.SetLayerWeight(2,1);
            if(tipoDano==1)
                health -= enemyDamage;
            else
                if(tipoDano==2)
                    health -= bulletDamage;
            sofrerDano = false;
        }
        else{
            animator.SetBool("dano", false);
            animator.SetLayerWeight(2,0);
        }
    }
    private void Movimentar(float h){
        if(!animator.GetCurrentAnimatorStateInfo(0).IsTag("Atirar")){
            rb2D.velocity = new Vector2(h*velocidade, rb2D.velocity.y);
        }
        animator.SetFloat("velocidade", Mathf.Abs(h));
        if(rb2D.velocity.y == 0){
            //rb2D.gravityScale = 1.0f;
        }
    }
    private void MudarDirecao(float horizontal){
        if(horizontal>0 && !eLadoDireito || horizontal<0 && eLadoDireito){
            eLadoDireito = !eLadoDireito;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            if (!eLadoDireito) {
                healthBar.transform.rotation = Quaternion.Euler(Vector3.up * 180);
                energyBar.transform.rotation = Quaternion.Euler(Vector3.up * 180);
            }
            if (eLadoDireito){
                healthBar.transform.rotation = Quaternion.Euler(Vector3.zero);
                energyBar.transform.rotation = Quaternion.Euler(Vector3.zero);
            }

        } 
    }
    private void ControlarEntradas(){
        if(Input.GetKeyDown(KeyCode.X) && !sofrerDano){
            acao = true;
        }
        if (Input.GetKeyDown ("up") && !sofrerDano) {
            Pular();
            animator.SetTrigger("pular");
		}
    }
    void Resetar(){
        acao = false;
    }
    void Acao(){
        if(acao && !animator.GetCurrentAnimatorStateInfo(0).IsTag("Atirar")){
            animator.SetTrigger("atirar");
            AcaoAtirar();
        }
    }
    private void AcaoAtirar(){
        GameObject tmpProjetil = (GameObject) (Instantiate(projetil, posicaoProjetil.transform.position, Quaternion.identity));
        tmpProjetil.name = "Player Bullet";
        tmpProjetil.tag = "Player";
        if(eLadoDireito){
            tmpProjetil.GetComponent<Bala>().Inicializar(Vector2.right);
        }
        else{
            tmpProjetil.GetComponent<Bala>().Inicializar(Vector2.left);
        }
    }

    void OnCollisionEnter2D (Collision2D collision) {
        if (collision.transform.tag.Contains("Ground"))
		    jumpLimit = 1; 
        if (collision.transform.tag.Contains("Enemy"))//para mais inimigos, adicionar condicoes para diferencia-los
            if (health > 0){
                tipoDano = 1;
                sofrerDano = true;
                Debug.Log ("fooooooi2");
            }
        if (collision.transform.name.Contains("Bullet") && collision.transform.tag.Contains("Enemy"))
            if (health > 0) {
                tipoDano = 2;
                sofrerDano = true;
                Debug.Log("fooooooi");
            }
    }

	void OnCollisionExit2D (Collision2D collision) {
        if (collision.transform.tag.Contains("Ground"))
            jumpLimit = 0;
	}

    private void OnTriggerEnter2D(Collider2D collision) {
              
    }

    private void OnCollisionStay2D(Collision2D collision) {            
        if (collision.transform.tag.Contains("Enemy"))//para mais inimigos, adicionar condicoes para diferencia-los
            if (health > 0){
                sofrerDano = true;
                tipoDano = 1;
                Debug.Log ("fooooooi2");
            }
    }

    private void EstaNoChao(){
        var pontoPosicao = pontoColisaoPiso;
        pontoPosicao.x += transform.position.x;
        pontoPosicao.y += transform.position.y;
        estaNoChao = Physics2D.OverlapCircle(pontoPosicao, raio, plataforma);
        Cair();

    }
    void OnDrawGizmos(){
        Gizmos.color = debugCorColisao;
        var pontoPosicao = pontoColisaoPiso;
        pontoPosicao.x += transform.position.x;
        pontoPosicao.y += transform.position.y;
        estaNoChao = Physics2D.OverlapCircle(pontoPosicao, raio, plataforma);
        Gizmos.DrawWireSphere(pontoPosicao, raio);
    }
    void Pular(){
        rb2D.gravityScale = 1.5f;
        if(estaNoChao && rb2D.velocity.y <= 0){
            rb2D.AddForce(new Vector2(0, jumpImpulse));
        }
    }
    private void Cair(){
        if(!estaNoChao && rb2D.velocity.y<=0){
            animator.SetBool("cair", true);
            animator.ResetTrigger("pular");
        }
        if(estaNoChao){
            animator.SetBool("cair", false);
        }
    }
    void ControlarLayers(){
        if(!estaNoChao && !animator.GetCurrentAnimatorStateInfo(0).IsTag("Atirar") && !animator.GetCurrentAnimatorStateInfo(2).IsTag("sofrerDano")){
            animator.SetLayerWeight(1,1);
        }
        else{
            animator.SetLayerWeight(1,0);
        }
    }

    private void consumeEnergy() {
        if (Input.GetKey(KeyCode.X) && energy > 0)//definir (botao de parar o tempo)
            energy -= energyConsumeRate;
    }

}
