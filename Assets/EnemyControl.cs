using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {
    public float speed = 2.0f;
    public float _gravity = 2f;
    private Rigidbody2D rb;
    private TimeManager localTime;
    private Gravity gravity;
    public bool isGrounded = false;

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
    }

    void FixedUpdate()
    {
        //if(gravity.isGrounded)
            movePlatform();
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
        theScale.x *= -1;
        transform.localScale = theScale;
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
