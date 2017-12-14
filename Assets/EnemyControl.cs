using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyControl : MonoBehaviour {
    public float speed = 2.0f;
    public float _gravity = 2f;
    public bool isGrounded = false;   

    private Rigidbody2D rb;
    private TimeManager localTime;
    private Gravity gravity;

    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private float bulletDamage;
    [SerializeField]
    private float playerDamage;

    private float health;
    private Image fillerHealth;
    private GameObject healthBar;


    void Start()
    {
        localTime = GameObject.Find("TimeManager").GetComponent<TimeManager>();       
        rb = GetComponent<Rigidbody2D>();
        gravity = GetComponent<Gravity>();
        if (localTime == null)
            Debug.Log("Nao existe um TimeManager");
        if (gravity == null)
            Debug.Log("Nao existe Script Gravity");
        isGrounded = false;

        fillerHealth = transform.Find("Health Canvas").GetChild(0).GetChild(0).GetComponent<Image>();
        healthBar = transform.Find("Health Canvas").gameObject;
        health = maxHealth;
        fillerHealth.fillAmount = health / maxHealth;
    }

    void FixedUpdate()
    {
        //if(gravity.isGrounded)

		if (Player.paused) {
			rb.constraints = RigidbodyConstraints2D.FreezeAll;
		} else {
			rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            movePlatform();
		}

        fillerHealth.fillAmount = health / maxHealth;
    }
    void movePlatform()
    {
        Vector2 newPosition;
        if (!isGrounded)
            newPosition = new Vector2(transform.position.x + speed * localTime.localDeltaTime(), transform.position.y - _gravity * localTime.localDeltaTime());
        else
            newPosition = new Vector2(transform.position.x + speed * localTime.localDeltaTime(), transform.position.y);
        rb.MovePosition(newPosition);       
    }
    void Flip()
    {
        Vector3 theScale = transform.localScale;
        if (theScale.x > 0)
            healthBar.transform.rotation = Quaternion.Euler(Vector3.up * 180);
        else
            healthBar.transform.rotation = Quaternion.Euler(Vector3.zero);
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag.Contains("Player"))
            if (health > 0) {
                health -= playerDamage;
            }
        if (collision.transform.name.Contains("Bullet") && collision.transform.tag.Contains("Player"))
            if (health > 0) {
                health -= bulletDamage;
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ChangeDirTrigger"))
        {
            speed *= -1;
            Flip();
        }

    }
}
