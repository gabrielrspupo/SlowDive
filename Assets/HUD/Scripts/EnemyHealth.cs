using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float bulletDamage;
    [SerializeField]
    private float playerDamage;

    private float health;
    private Image filler;
    private GameObject healthBar;
    private Quaternion healthRotation;

    // Use this for initialization
    void Start() {        
        filler = transform.Find("Health Canvas").GetChild(0).GetChild(0).GetComponent<Image>();
        healthBar = transform.Find("Health Canvas").GetChild(0).gameObject;
        healthRotation = healthBar.transform.rotation;
        health = maxHealth;
        filler.fillAmount = health / maxHealth;
    }

    // Update is called once per frame
    private void FixedUpdate() {
        testHealthBar();
        filler.fillAmount = health / maxHealth;
        healthBar.transform.rotation = healthRotation;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.name.Contains("Bullet"))
            if (health > 0)
                health -= bulletDamage;
        if (collision.transform.tag.Contains("Player"))
            if (health > 0)
                health -= playerDamage;
    }

    /* test */
    private void testHealthBar() {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            if (health > 0)
                health -= 10f;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            if (health < maxHealth)
                health += 10f;
        }
        if (health <= 0)
            GameObject.Destroy(this.gameObject);
    }
}
