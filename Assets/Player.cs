using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //Make sure that we can see class in Inspector
    [System.Serializable]
    public class PlayerStats {
        public float Health = 100f;

    }

    PlayerStats playerStats = new PlayerStats();
    public float fallBoundary = -15;
	public float speed = 5;
	public float jumpImpulse = 10;
	private int jumpLimit = 1;
	private Rigidbody2D rb2d;
	private SpriteRenderer sr;

	void Start() {
		rb2d = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
	}

    public void DamagePlayer(int damage) {
        playerStats.Health -= damage;
        if(playerStats.Health <= 0) {
            Debug.Log("Kill Player");
            GameManager.KillPlayer(this);
        }
    }

	void OnCollisionEnter2D (Collision2D collision) {
		jumpLimit = 1;
	}

	void OnCollisionExit2D (Collision2D collision) {
		jumpLimit = 0;
	}

    void Update() {
        if (transform.position.y <= fallBoundary) {
            DamagePlayer(int.MaxValue);
        }
    }

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		Vector2 pos = transform.position;

		if (Input.GetKeyDown ("up") && jumpLimit >= 0) {
			rb2d.AddForce (new Vector2 (0, jumpImpulse), ForceMode2D.Impulse);
			jumpLimit--;
		} else {
			rb2d.AddForce (new Vector2 (moveHorizontal, 0) * speed);
			if (moveHorizontal < 0)
				sr.flipX = true;
			else
				sr.flipX = false;
		}
	}
}
