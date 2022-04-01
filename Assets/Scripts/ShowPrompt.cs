using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPrompt : MonoBehaviour
{
    public GameObject thing;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
        thing.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            thing.gameObject.SetActive(false);
        }
    }
}
