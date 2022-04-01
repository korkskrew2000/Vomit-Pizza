using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoNextLevel : MonoBehaviour
{
    public Animator anim;
    public int secondstoWait = 2;


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            anim.SetBool("transition", true);
            StartCoroutine(LevelTransition());
        }
    }

    public IEnumerator LevelTransition() {
        yield return new WaitForSeconds(secondstoWait);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
