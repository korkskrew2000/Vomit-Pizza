using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPainTouch : MonoBehaviour
{

    public int takenDamageAmount = 20;
    public void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<Player>().TakeDamage(takenDamageAmount);
        }
    }
}
