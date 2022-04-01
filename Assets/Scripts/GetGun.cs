using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGun : MonoBehaviour
{
    public GameObject gunPanel;
    public Shoot shoot;
    public AudioSource audios;
    public GameObject gun;
    public GameObject curcle;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            audios.PlayOneShot(audios.clip);
            gunPanel.gameObject.SetActive(true);
            shoot.enabled = true;
            gun.gameObject.SetActive(false);
            curcle.gameObject.SetActive(false);
            StartCoroutine(Fuck());
        }
    }

    public IEnumerator Fuck() {
        yield return new WaitForSeconds(4f);
        this.gameObject.SetActive(false);
    }
}
