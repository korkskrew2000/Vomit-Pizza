using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodsplurt : MonoBehaviour
{
    public float lifeCounter = 3f;
    public float speed = 20f;
    public Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void Update() {
        lifeCounter -= Time.deltaTime;
        if (lifeCounter <= 0) {
            Destroy(gameObject);
        }
    }
}
