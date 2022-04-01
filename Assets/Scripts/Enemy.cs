using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool sentient;
    public int maxHealth = 100;
    public int currentHealth;
    public float moveSpeed;
    public bool enemyCantMove = false;
    Animator anim;
    public GameObject deathfunnyPrefab;
    public GameObject hurtBox;
    public Transform player;
    Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        enemyCantMove = FindObjectOfType<DialogueSystem>().isTalking;

        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        if (sentient) { 
            currentHealth = maxHealth;
        } else {
            currentHealth = 1;
        }

    }

    private void Update() {
        if(FindObjectOfType<DialogueSystem>().isTalking == true) {
            enemyCantMove = true;
        } else {
            enemyCantMove = false;
        }

        if (sentient) {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
        } else {
            return;
        }
    }

    private void FixedUpdate() {
        if (sentient && !enemyCantMove) {
            EnemyMove(movement);
        } else {
            return;
        }
    }

    void EnemyMove(Vector2 direction) {
        rb.MovePosition((Vector2)transform.position + direction * moveSpeed * Time.deltaTime);
    }


    public void TakeDamage(int damage) {
        currentHealth -= damage;
        if(currentHealth <= 0) {
            Abolition();
        }
    }

    void Abolition() {
        anim.SetBool("Dead", true);
        GetComponent<Collider2D>().enabled = false;
        if (sentient) {
            this.gameObject.SetActive(false);
            hurtBox.gameObject.SetActive(false);
            Instantiate(deathfunnyPrefab, transform.position, deathfunnyPrefab.transform.rotation);
        } else {
            return;
        }
        this.enabled = false;
    }
}
