using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pain : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("FeelsPain")) {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(100);
        }
    }
}
